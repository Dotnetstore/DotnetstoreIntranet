using System.Reflection;
using Dotnetstore.Intranet.API.Organization.Extensions;
using Dotnetstore.Intranet.API.SharedKernel.Extensions;
using FastEndpoints;
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
            .AddFastEndpoints()
            .AddSharedKernel(mediatorAssemblies)
            .AddOrganization(configuration)
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

        // services
        //     .AddHostedService<WorkerService>()
        //     .AddFastEndpoints()
        //     .AddAuthenticationJwtBearer(s => s.SigningKey = "Det här är en hemlighet för att signera token. Byt ut den i produktion. Den duger i testmiljö.")
        //     .AddAuthorization()
        //     .AddUtility(mediatorAssemblies)
        //     .AddOrganization(configuration, mediatorAssemblies)
        //     .SwaggerDocument(o =>
        //     {
        //         o.DocumentSettings = s =>
        //         {
        //             s.Title = "Dotnetstore Intranet API";
        //             s.Description = "API for Dotnetstore Intranet";
        //             s.Version = "1.0";
        //         };
        //     })
        //     .AddProblemDetails();
    }
}