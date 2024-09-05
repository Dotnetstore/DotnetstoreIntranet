using System.Reflection;
using Dotnetstore.Intranet.WebAPI.Organization.Data;
using Dotnetstore.Intranet.WebAPI.Utility.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnetstore.Intranet.WebAPI.Organization.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddOrganization(
        this IServiceCollection services,
        IConfiguration configuration, 
        List<Assembly> mediatorAssemblies)
    {
        mediatorAssemblies.Add((Assembly)typeof(IOrganizationAssemblyMarker).Assembly);
        
        var connectionString = configuration.GetConnectionString("IntranetConnectionString");
        ArgumentException.ThrowIfNullOrWhiteSpace(connectionString, nameof(connectionString));

        services
            .AddScoped<IOrganizationUnitOfWork, OrganizationUnitOfWork>()
            .AddDbContext<OrganizationDataContext>(connectionString)
            .EnsureDbCreated<OrganizationDataContext>();
        //     .AddScoped<IUserRepository, UserRepository>()
        //     .AddScoped<IUserService, UserService>()
        //     .AddFastEndpoints()
        //     .AddDbContext<OrganizationDataContext>(connectionString);
        
        using var scope = services.BuildServiceProvider().CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<OrganizationDataContext>();
        
        context.Database.EnsureCreated();

        return services;
    }
}