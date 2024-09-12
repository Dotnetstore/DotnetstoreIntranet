using System.Reflection;
using Dotnetstore.Intranet.WebAPI.Organization.Extensions;
using Dotnetstore.Intranet.WebAPI.Services;
using Dotnetstore.Intranet.WebAPI.Utility.Extensions;
using FastEndpoints;
using FastEndpoints.Security;
using FastEndpoints.Swagger;

namespace Dotnetstore.Intranet.WebAPI.Extensions;

internal static class ServiceColletionExtensions
{
    internal static void AddWebApi(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        List<Assembly> mediatorAssemblies = [typeof(ServiceColletionExtensions).Assembly];
        
        services
            .AddHostedService<WorkerService>()
            .AddFastEndpoints()
            .AddAuthenticationJwtBearer(s => s.SigningKey = "Det här är en hemlighet för att signera token. Byt ut den i produktion. Den duger i testmiljö.")
            .AddAuthorization()
            .AddUtility(mediatorAssemblies)
            .AddOrganization(configuration, mediatorAssemblies)
            .SwaggerDocument(o =>
            {
                o.DocumentSettings = s =>
                {
                    s.Title = "Dotnetstore Intranet API";
                    s.Description = "API for Dotnetstore Intranet";
                    s.Version = "1.0";
                };
            })
            .AddProblemDetails();
    }
}