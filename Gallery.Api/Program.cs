using Gallery.Application;
using Gallery.Core.Enums;
using Gallery.Extensions;
using Gallery.Infrastructure;
using Gallery.Infrastructure.Authentication;
using Gallery.Middlewares;
using Gallery.Persistence;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var AllowSpecificOrigins = "allowSpecificOrigins";
builder.Host.UseSerilog((context, loggerConfig) =>
    loggerConfig.ReadFrom.Configuration(context.Configuration));

var services = builder.Services;
var configuration = builder.Configuration;

services.AddCors(options =>
{
    options.AddPolicy(AllowSpecificOrigins,policy =>
    {
        policy.WithOrigins("https://localhost:5173").SetIsOriginAllowed((host) => true);
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowCredentials();

    });
});
services.AddApiAuthentication(configuration);

services.AddEndpointsApiExplorer();

services.AddSwaggerGen();

services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));
services.Configure<AuthorizationOptions>(configuration.GetSection(nameof(AuthorizationOptions)));

services
    .AddPersistence(configuration)
    .AddApplication()
    .AddInfrastructure();

builder.Services.AddProblemDetails();
services.AddExceptionHandler<GlobalExceptionHandler>();

services.AddAutoMapper(typeof(DataBaseMappings));

var app = builder.Build();

app.UseCors(AllowSpecificOrigins);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseExceptionHandler();

app.UseMiddleware<RequestLogContextMiddleware>();

app.UseSerilogRequestLogging();

app.UseCookiePolicy(new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Lax,
    HttpOnly = HttpOnlyPolicy.Always,
    Secure = CookieSecurePolicy.None
});

app.UseAuthentication();

app.UseAuthorization();

app.AddMappedEndpoints();

app.MapGet("get", () =>
{
    return Results.Ok("ok");
}).RequirePermissions(Permission.Read);

app.Run();