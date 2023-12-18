using SmileKitty.EventBus.Event;

namespace SmileKitty.EventBus.Core;

public interface ILocalEventManager
{
    void OnSub();
}

public interface ILocalEventManager<in TEvent> : ILocalEventManager where TEvent : IEvent
{
    Task PubAsync(TEvent @event);
}