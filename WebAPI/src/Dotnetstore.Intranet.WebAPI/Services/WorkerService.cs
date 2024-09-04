namespace Dotnetstore.Intranet.WebAPI.Services;

internal sealed class WorkerService(IConfiguration configuration) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            // if (logger.IsEnabled(LogLevel.Information))
            // {
            //     logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            // }
            
            var delay = configuration.GetValue<TimeSpan>("WorkerDelay");
            
            await Task.Delay(delay, stoppingToken);
        }
    }
}