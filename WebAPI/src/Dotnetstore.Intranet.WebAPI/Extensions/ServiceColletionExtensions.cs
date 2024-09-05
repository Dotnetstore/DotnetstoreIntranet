using Dotnetstore.Intranet.WebAPI.Services;
using FastEndpoints;

namespace Dotnetstore.Intranet.WebAPI.Extensions;

internal static class ServiceColletionExtensions
{
    internal static void AddWebApi(
        this IServiceCollection services)
    {
        services
            .AddHostedService<WorkerService>()
            .AddFastEndpoints();
    }
}