using Microsoft.Extensions.DependencyInjection;
using SmileKitty.Application.Exceptions;
using SmileKitty.EventBus.Event;
using SmileKitty.EventBus.Extensions;
using SmileKitty.EventBus.Handler;

namespace SmileKitty.Application;

public static class SmileKittyApplicationExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        var eventTypes = typeof(IEvent).Assembly.GetTypes().Where(x =>
            typeof(IEvent).IsAssignableFrom(x) && x is { IsInterface: false, IsAbstract: false }).ToArray();
        var handlerTypes = typeof(IEventHandler<>).Assembly.GetTypes().Where(x =>
            typeof(IEventHandler<>).IsAssignableFrom(x) && x is { IsInterface: false, IsAbstract: false }).ToArray();

        foreach (var eventType in eventTypes)
        {
            var handlerType = handlerTypes.FirstOrDefault(x => x.GetInterfaces().Any(y => y.GetGenericArguments().Any(z => z == eventType)));
            services.AddEventHandler(handlerType ?? throw new HandlerNotFoundException($"@handler = {eventType.Name}HandlerNotFound, @event = {eventType.Name}"), eventType);
        }
    }
}