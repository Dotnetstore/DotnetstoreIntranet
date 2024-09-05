using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnetstore.Intranet.WebAPI.Utility.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDbContext<T>(this IServiceCollection services, string connectionString) where T : DbContext
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(connectionString, nameof(connectionString));
        
        services.AddDbContext<T>(options =>
        {
            options.UseSqlServer(connectionString);
        });
        
        return services;
    }
    
    public static void EnsureDbCreated<T>(this IServiceCollection services) where T : DbContext
    {
        using var scope = services.BuildServiceProvider().CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<T>();
        context.Database.EnsureCreated();
    }
}