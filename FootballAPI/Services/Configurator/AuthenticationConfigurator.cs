namespace FootballApi.Services.Configurator
{
    using FootballApi.Common.Configuration;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Logging;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Class AuthenticationConfigurator.
    /// </summary>
    public static class AuthenticationConfigurator
    {
        /// <summary>
            /// Adds the JWT authentication.
            /// </summary>
            /// <param name="services">The services.</param>
            /// <param name="configuration">The configuration.</param>
            /// <returns>TokenValidationParameters.</returns>
        public static TokenValidationParameters AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            // Authentication
            var authenticationConfiguration = configuration.GetSection(nameof(AuthenticationConfiguration)).Get<AuthenticationConfiguration>();
            var secretBytes = System.Text.Encoding.ASCII.GetBytes(authenticationConfiguration.Secret);
            var signingKey = new SymmetricSecurityKey(secretBytes);

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateActor = false,
                ValidateTokenReplay = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = false,
                IssuerSigningKey = signingKey,
                ClockSkew = TimeSpan.Zero,
            };

            IdentityModelEventSource.ShowPII = true;

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddCookie("Identity.Application")
            .AddJwtBearer(options =>
            {
                options.IncludeErrorDetails = false;
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = tokenValidationParameters;
                options.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        //// if there is no access token in headers we try to grab it from query string
                        //var accessToken = context.Request.Query["access_token"];

                        //if (string.IsNullOrEmpty(context.Token) && !string.IsNullOrEmpty(accessToken))
                        //{
                        //    context.Token = accessToken;
                        //}

                        // throw new UnauthorizedAccessException();

                        return Task.CompletedTask;
                    }
                };

            });

            return tokenValidationParameters;
        }
    }
}
