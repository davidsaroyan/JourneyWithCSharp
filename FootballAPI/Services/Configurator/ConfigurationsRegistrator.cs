using FootballApi.Common.Configuration;
using Microsoft.Extensions.Configuration;

namespace FootballApi.Services.Configurator
{
    public static class ConfigurationsRegistrator
    {
        public static void RegisterConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            // Authentication
            var authenticationConfiguration = configuration.GetSection(nameof(AuthenticationConfiguration)).Get<AuthenticationConfiguration>();
            if (authenticationConfiguration is not null)
            {
                services.AddSingleton(authenticationConfiguration);
            }

            //services.AddSingleton<DBConfiguration>(configuration.GetSection(nameof(DBConfiguration)).Get<DBConfiguration>());
            //services.AddSingleton<RedisConfiguration>(configuration.GetSection(nameof(RedisConfiguration)).Get<RedisConfiguration>());
        }
    }
}
