using Gallery.Application.Services;
using Gallery.Core.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Gallery.Application;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<PhotoService>();
        services.AddScoped<UserService>();
        services.AddScoped<AlbumService>();
        return services;
    }
    
}