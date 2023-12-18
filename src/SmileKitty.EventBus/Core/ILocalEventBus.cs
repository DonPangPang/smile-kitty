using SmileKitty.EventBus.Event;

namespace SmileKitty.EventBus.Core;

public interface ILocalEventBus<in TEvent> where TEvent : IEvent
{
    Task PublishAsync(TEvent @event);
}