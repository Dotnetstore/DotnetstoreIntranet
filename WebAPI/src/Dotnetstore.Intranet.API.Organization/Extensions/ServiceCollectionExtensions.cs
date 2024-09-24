using Dotnetstore.Intranet.API.Organization.Data;
using Dotnetstore.Intranet.API.Organization.Users;
using Dotnetstore.Intranet.API.SharedKernel.Extensions;
using FastEndpoints;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnetstore.Intranet.API.Organization.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddOrganization(
        this IServiceCollection services,
        IConfiguration configuration)
    {
         var connectionString = configuration.GetConnectionString("IntranetConnectionString");
         ArgumentException.ThrowIfNullOrWhiteSpace(connectionString, nameof(connectionString));

         return services
             .AddFastEndpoints()
             .AddScoped<IOrganizationUnitOfWork, OrganizationUnitOfWork>()
             .AddScoped<IUserRepository, UserRepository>()
             .AddScoped<IUserService, UserService>()
             .AddDbContext<OrganizationDataContext>(connectionString);
    }
}