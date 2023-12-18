using Microsoft.Extensions.DependencyInjection;
using SmileKitty.EventBus.Consts;
using SmileKitty.EventBus.Core;
using SmileKitty.EventBus.Handler;

namespace SmileKitty.EventBus.Extensions;

public static class SmileKittyEventBusExtensions
{
    public static IServiceCollection AddSmileKittyEventBus(this IServiceCollection services,
        Action<SmileKittyEventBusOptions> options)
    {
        var smileKittyEventBusOptions = new SmileKittyEventBusOptions();
        options.Invoke(smileKittyEventBusOptions);
        services.AddSingleton(smileKittyEventBusOptions);
        services.AddSingleton(typeof(ILocalEventManager<>), typeof(LocalEventManager<>));
        services.AddSingleton<ILocalEventBus, LocalEventBus>();

        services.AddHostedService<LocalEventBusHostedService>();
        return services;
    }
}