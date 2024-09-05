using Dotnetstore.Intranet.WebAPI.Utility.Models;
using FastEndpoints;
using Microsoft.Extensions.Logging;

namespace Dotnetstore.Intranet.WebAPI.Utility.Loggers;

public sealed class RequestLogger<TRequest> : PreProcessor<TRequest, StateBag>
{
    public override Task PreProcessAsync(IPreProcessorContext<TRequest> context, StateBag state, CancellationToken ct)
    {
        var logger = context.HttpContext.Resolve<ILogger<TRequest>>();
        
        logger.LogInformation($"request:{context.Request.GetType().FullName} path: {context.HttpContext.Request.Path}");
        
        return Task.CompletedTask;
    }
}