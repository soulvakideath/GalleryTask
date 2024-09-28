using Gallery.Application.Auth;
using Gallery.Infrastructure.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace Gallery.Infrastructure;

public static class InfrastructureExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IJwtProvider, JwtProvider>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        return services;
    }
}