using FootballApi.Common.Configuration;
using Microsoft.OpenApi.Models;

namespace FootballApi.Services.Configurator
{
    public static class SwaggerConfigurator
    {
        public static void ConfigureSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            SwaggerConfigurationModel model = configuration.GetSection("SwaggerConfigurationModel").Get<SwaggerConfigurationModel>();

            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc(
                model.Name,
                new OpenApiInfo
                {
                    Title = model.Title,
                    Version = model.Version,
                    Description = model.Description
                });

                option.CustomSchemaIds(type => type.FullName);
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                });

                //option.CustomSchemaIds(type => type.Name);
                option.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                {
                 new OpenApiSecurityScheme
                {
 Reference = new OpenApiReference
 {
 Type = ReferenceType.SecurityScheme,
 Id = "Bearer"
 },
 Scheme = "oauth2",
 Name = "Bearer",
 In = ParameterLocation.Header,
 },
 new List<string>()
 }
 });
            });
        }

        public static void UseSwagger(this IApplicationBuilder app, IConfiguration configuration)
        {
            app.UseSwagger();

            Dictionary<string, string> swaggerEndpoints = configuration.GetSection("SwaggerEndpoint").Get<Dictionary<string, string>>();

            app.UseSwaggerUI(setupAction =>
            {
                setupAction.ConfigObject.AdditionalItems.Add("persistAuthorization", "true");
                foreach (var endpoint in swaggerEndpoints)
                {
                    setupAction.SwaggerEndpoint(endpoint.Key, endpoint.Value);
                }
            });
        }

    }
}
