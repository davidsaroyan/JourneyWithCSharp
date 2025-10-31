using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
namespace FootballApi.Services.Configurator
{
    public static class ControllerConfigurator
    {
        public static void RegisterControllers(this IServiceCollection services)
        {
            // Disable automatic model validation
            services.Configure<Microsoft.AspNetCore.Mvc.ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddControllers()
            .AddNewtonsoftJson(options =>
            {
                // Configure Newtonsoft json
                var settings = options.SerializerSettings;
                settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                settings.DateTimeZoneHandling = DateTimeZoneHandling.Unspecified;
                JsonConvert.DefaultSettings = () => settings;
            });
        }
    }
}
