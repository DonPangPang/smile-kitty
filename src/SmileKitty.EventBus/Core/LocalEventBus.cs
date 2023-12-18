using SmileKitty.EventBus.Event;

namespace SmileKitty.EventBus.Core;

public class LocalEventBus<TEvent>(ILocalEventManager<TEvent> localEventManager) : ILocalEventBus<TEvent> where TEvent : IEvent
{
    private readonly ILocalEventManager<TEvent> _localEventManager = localEventManager;

    public async Task PublishAsync(TEvent @event)
    {
        await _localEventManager.PubAsync(@event);
    }
}