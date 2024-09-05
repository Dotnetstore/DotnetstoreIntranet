using Dotnetstore.Intranet.WebAPI.Utility.Models;
using FastEndpoints;
using Microsoft.Extensions.Logging;

namespace Dotnetstore.Intranet.WebAPI.Utility.Loggers;

public sealed class DurationLogger<TRequest> : PostProcessor<TRequest, StateBag, object>
{
    public override Task PostProcessAsync(
        IPostProcessorContext<TRequest, object> ctx, 
        StateBag state, 
        CancellationToken ct)
    {
        ctx.HttpContext.Resolve<ILogger<DurationLogger<TRequest>>>().LogInformation("request took {@duration} ms.", state.DurationMillis);

        return Task.CompletedTask;
    }
}