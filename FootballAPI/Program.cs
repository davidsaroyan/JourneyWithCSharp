using FootballApi.DataAccess.DbContexts;
using FootballApi.Services;
using FootballApi.Services.Configurator;
using FootballApi.Services.Filter;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add Controlles
builder.Services.RegisterControllers();

// Add swagger
builder.Services.ConfigureSwagger(configuration);

// Add Authorization
var tokenValidationParameters = builder.Services.AddJwtAuthentication(configuration);
var authorizationPolicy = new AuthorizationPolicyBuilder()
 .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
 .RequireAuthenticatedUser()
 .Build();

builder.Services.ConfigureFilters(tokenValidationParameters, authorizationPolicy, configuration);

// Register configurations
builder.Services.RegisterConfigurations(configuration);

// Add Required Service.
builder.Services.AddScoped<FootballService>();
builder.Services.AddScoped<AccountService>();

builder.Services.AddEndpointsApiExplorer();

// Add StackExcahange
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = configuration.GetValue<string>("Redis:ConnectionString");
    options.InstanceName = "FootballApi_";
});

builder.Services.AddDbContext<PostgresDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// If using kestrel:
builder.Services.Configure<KestrelServerOptions>(options =>
{
    options.AllowSynchronousIO = true;
});

// If using IIS:
builder.Services.Configure<IISServerOptions>(options =>
{
    options.AllowSynchronousIO = true;
});

var app = builder.Build();

// ----- Middleware pipeline -----
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger(configuration);
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers(); // simpler than UseEndpoints()

app.Run();