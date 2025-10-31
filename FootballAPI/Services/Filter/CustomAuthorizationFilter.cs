namespace FootballApi.Services.Filter
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Authorization;
    using Microsoft.AspNetCore.Mvc.Controllers;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.IdentityModel.Tokens;

    public class CustomAuthorizeFilter : AuthorizeFilter
    {
        private readonly TokenValidationParameters _tokenValidationParameters;
        public CustomAuthorizeFilter(TokenValidationParameters tokenValidationParameters, AuthorizationPolicy authorizationPolicy)
 : base(authorizationPolicy)
        {
            _tokenValidationParameters = tokenValidationParameters;
        }

        protected async Task<(bool, string)> OnCustomAuthorizationAsync(AuthorizationFilterContext context)
        {
            var token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                var claimsPrincipal = tokenHandler.ValidateToken(token, _tokenValidationParameters, out SecurityToken validatedToken);
                await context.HttpContext.SignInAsync(IdentityConstants.ApplicationScheme, claimsPrincipal);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }

            return (true, string.Empty);
        }


        protected void Unauthorized(AuthorizationFilterContext context, string message = "")
        {
            var response = new 
            {
                Message = message,
            }
            ;
            context.Result = new UnauthorizedObjectResult(response);
        }
    }
}


