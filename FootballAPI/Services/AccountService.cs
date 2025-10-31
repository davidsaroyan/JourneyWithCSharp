using FootballApi.Common.Configuration;
using FootballApi.Common.DTO;
using FootballApi.Common.Entities;
using FootballApi.DataAccess.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace FootballApi.Services
{
    public class AccountService
    {
        private readonly PostgresDbContext _context;
        private readonly AuthenticationConfiguration _authConfig;
        private readonly IDistributedCache _cache;


        public AccountService(PostgresDbContext context, AuthenticationConfiguration authConfig,IDistributedCache cache)
        {
            _context = context;
            _authConfig = authConfig;
            _cache = cache;
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            // Check user in database
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.UserName == request.UserName && u.Password == request.PassWord);

            if (user == null)
            {
                return null; // Login failed
            }

            // Generate JWT token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_authConfig.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim("UserId", user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(_authConfig.AccessTokenLifeTimeMinutes ?? 30),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var response = tokenHandler.WriteToken(token);
            var refreshToken = await this.GenerateRefreshTokenAsync();
            return new LoginResponse { Token = response, RefreshToken = refreshToken };
        }

        public async Task<LoginResponse> RefreshTokenAsync(RefreshTokenRequest request)
        {
            var refreshToken = await this.GetFromCacheAsync(request.RefreshTokenId);
            if (refreshToken == null) 
                return new LoginResponse();
            // Check user in database
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == refreshToken.UserId);

            if (user == null)
            {
                return null; // Login failed
            }

            // Generate JWT token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_authConfig.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim("UserId", user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(_authConfig.AccessTokenLifeTimeMinutes ?? 30),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var response = tokenHandler.WriteToken(token);
            var newRefreshToken = await this.GenerateRefreshTokenAsync();
            return new LoginResponse { Token = response, RefreshToken = newRefreshToken };
        }
        private async Task<string> GenerateRefreshTokenAsync()
        {
            var refreshToken = new RefreshToken();
            var serializedToken = Newtonsoft.Json.JsonConvert.SerializeObject(refreshToken);

            // Cache the response
            await _cache.SetStringAsync(refreshToken.RefreshTokenId, serializedToken, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(_authConfig.RefreshTokenLifeTimeMinutes ?? 30)
            });

            return refreshToken.RefreshTokenId;
        }

        public async Task<RefreshToken?> GetFromCacheAsync(string refreshTokenId)
        {
            var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            // trying to get from cache
            var cachedJson = await _cache.GetStringAsync(refreshTokenId);
            if (cachedJson != null)
            {
                return JsonSerializer.Deserialize<RefreshToken>(cachedJson, jsonOptions);
            }

            return null;
        }
    }
}
