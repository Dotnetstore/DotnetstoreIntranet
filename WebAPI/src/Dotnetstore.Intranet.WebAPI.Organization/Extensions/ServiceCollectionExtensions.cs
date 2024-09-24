// using System.Reflection;
// using Dotnetstore.Intranet.WebAPI.Organization.Data;
// using Dotnetstore.Intranet.WebAPI.Organization.UserInUserRoles;
// using Dotnetstore.Intranet.WebAPI.Organization.Users;
// using Dotnetstore.Intranet.WebAPI.Utility.Extensions;
// using FastEndpoints;
// using Microsoft.Extensions.Configuration;
// using Microsoft.Extensions.DependencyInjection;
//
// namespace Dotnetstore.Intranet.WebAPI.Organization.Extensions;
//
// public static class ServiceCollectionExtensions
// {
//     public static IServiceCollection AddOrganization(
//         this IServiceCollection services,
//         IConfiguration configuration, 
//         List<Assembly> mediatorAssemblies)
//     {
//         mediatorAssemblies.Add(typeof(IOrganizationAssemblyMarker).Assembly);
//         
//         var connectionString = configuration.GetConnectionString("IntranetConnectionString");
//         ArgumentException.ThrowIfNullOrWhiteSpace(connectionString, nameof(connectionString));
//
//         services
//             .AddScoped<IOrganizationUnitOfWork, OrganizationUnitOfWork>()
//             .AddScoped<IUserInUserRoleRepository, UserInUserRoleRepository>()
//             .AddScoped<IUserInUserRoleService, UserInUserRoleService>()
//             .AddScoped<IUserRepository, UserRepository>()
//             .AddScoped<IUserService, UserService>()
//             .AddFastEndpoints()
//             .AddDbContext<OrganizationDataContext>(connectionString, true, false)
//             .EnsureDbCreated<OrganizationDataContext>();
//
//         return services;
//     }
// }