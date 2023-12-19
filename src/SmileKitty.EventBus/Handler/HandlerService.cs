using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SmileKitty.EventBus.Core;

namespace SmileKitty.EventBus.Handler;

public class LocalEventBusHostedService(IServiceProvider serviceProvider)
    : BackgroundService
{
     readonly IServiceProvider _serviceProvider = serviceProvider;

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        foreach (var manager in _serviceProvider.GetServices(typeof(ILocalEventManager<>)))
        {
            if (manager is ILocalEventManager eventManager)
            {
                eventManager.OnSub();
            }
        }

        return Task.CompletedTask;
    }
}