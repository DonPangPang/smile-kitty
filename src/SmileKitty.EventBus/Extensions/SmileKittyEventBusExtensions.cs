using Microsoft.Extensions.DependencyInjection;
using SmileKitty.EventBus.Consts;
using SmileKitty.EventBus.Core;
using SmileKitty.EventBus.Event;
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
        services.AddSingleton(typeof(ILocalEventBus<>), typeof(LocalEventBus<>));

        services.AddHostedService<LocalEventBusHostedService>();
        return services;
    }

    public static IServiceCollection AddEventHandler<TEventHandler, TEvent>(this IServiceCollection services)
        where TEventHandler : class, IEventHandler<TEvent> where TEvent : IEvent
    {
        services.AddScoped<IEventHandler<TEvent>, TEventHandler>();
        return services;
    }

    public static IServiceCollection AddEventHandler(this IServiceCollection services,
        Type eventHandlerType, Type eventType)
    {
        var eventHandlerInterfaceType = typeof(IEventHandler<>).MakeGenericType(eventType);
        services.AddScoped(eventHandlerInterfaceType, eventHandlerType);
        return services;
    }
}