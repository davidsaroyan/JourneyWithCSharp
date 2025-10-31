using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace FootballApi.Services.Filter
{
    public static class FilterConfigurator
    {
        public static void ConfigureFilters(this IServiceCollection services, TokenValidationParameters tokenValidationParameters, AuthorizationPolicy authorizationPolicy,  IConfiguration configuration)
        {
            services.AddSingleton(tokenValidationParameters);

            services.AddMvcCore(options =>
            {
                options.Filters.Add(new DefaultAuthorizeFilter(tokenValidationParameters, authorizationPolicy));

                //// Added response type examples
                //options.Filters.Add(new ProducesResponseTypeAttribute(typeof(Result), StatusCodes.Status400BadRequest));
                //options.Filters.Add(new ProducesResponseTypeAttribute(typeof(Result), StatusCodes.Status401Unauthorized));
                //options.Filters.Add(new ProducesResponseTypeAttribute(typeof(Result), StatusCodes.Status403Forbidden));
                //options.Filters.Add(new ProducesResponseTypeAttribute(typeof(Result), StatusCodes.Status404NotFound));
                //options.Filters.Add(new ProducesResponseTypeAttribute(typeof(Result), StatusCodes.Status500InternalServerError));
            });
        }
    }
}
