using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;

namespace FootballApi.Services.Filter
{
    public class DefaultAuthorizeFilter : CustomAuthorizeFilter
    {
        public DefaultAuthorizeFilter(TokenValidationParameters tokenValidationParameters, AuthorizationPolicy authorizationPolicy)
     : base(tokenValidationParameters, authorizationPolicy)
        {
        }

        public override async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var actionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
            if (actionDescriptor.MethodInfo.CustomAttributes.Any(p => p.AttributeType.Name == "AllowAnonymousAttribute"))
            {
                return;
            }

            // Authorization custom implementation.
            var validationResult = await OnCustomAuthorizationAsync(context);

            if (!validationResult.Item1)
            {
                Unauthorized(context, validationResult.Item2);
                return;
            }
        }
    }
}
