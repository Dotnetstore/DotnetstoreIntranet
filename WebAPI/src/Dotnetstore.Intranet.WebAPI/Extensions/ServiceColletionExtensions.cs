using Dotnetstore.Intranet.WebAPI.Services;

namespace Dotnetstore.Intranet.WebAPI.Extensions;

internal static class ServiceColletionExtensions
{
    internal static void AddWebAPI(this IServiceCollection services)
    {
        services
            .AddHostedService<WorkerService>();
    }
}