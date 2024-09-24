using System.Reflection;
using Dotnetstore.Intranet.API.SharedKernel.Repositories;
using EntityFramework.Exceptions.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnetstore.Intranet.API.SharedKernel.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSharedKernel(
        this IServiceCollection services,
        List<Assembly> mediatorAssemblies)
    {
        mediatorAssemblies.Add(typeof(ISharedKernelAssemblyMarker).Assembly);
        
        services
            .AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        
        return services;
    }
    
    public static IServiceCollection AddDbContext<T>(
        this IServiceCollection services, 
        string connectionString) where T : DbContext
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(connectionString, nameof(connectionString));
        
        services.AddDbContext<T>(options =>
        {
            options.UseSqlServer(connectionString)
                .UseExceptionProcessor();
        });
        
        return services;
    }
    
    public static void EnsureDbCreated<T>(this IServiceCollection services) where T : DbContext
    {
        using var scope = services.BuildServiceProvider().CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<T>();
        context.Database.EnsureCreated();
    }
    
    public static void RemoveDbContext<T>(this IServiceCollection services) where T : DbContext
    {
        var descriptor = services.SingleOrDefault(d => typeof(DbContextOptions<T>) == d.ServiceType);
        if (descriptor != null)
        {
            services.Remove(descriptor);
        }
    }
}