using System.Reflection;
using Dotnetstore.Intranet.WebAPI.Utility.Repositories;
using EntityFramework.Exceptions.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnetstore.Intranet.WebAPI.Utility.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddUtility(
        this IServiceCollection services,
        List<Assembly> mediatorAssemblies)
    {
        mediatorAssemblies.Add(typeof(IUtilityAssemblyMarker).Assembly);
        
        services
            .AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        
        return services;
    }
    
    public static IServiceCollection AddDbContext<T>(
        this IServiceCollection services, 
        string connectionString,
        bool useMsSql,
        bool usePostgre) where T : DbContext
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(connectionString, nameof(connectionString));
        
        services.AddDbContext<T>(options =>
        {
            if (useMsSql)
            {
                options.UseSqlServer(connectionString)
                    .UseExceptionProcessor();
            }
            else if (usePostgre)
            {
                options.UseNpgsql(connectionString)
                    .UseExceptionProcessor();
            }
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