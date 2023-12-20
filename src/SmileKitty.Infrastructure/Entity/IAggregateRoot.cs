using SmileKitty.EventBus.Event;
using System.Collections.Concurrent;

namespace SmileKitty.Infrastructure.Entity;

public interface IAggregateRoot : IEntity
{
    void AddLocalEvent<TEvent>(TEvent eventData) where TEvent : IEvent;
    bool GetLocalEvent(out object? @event);
    void ClearLocalEvents();
}

public abstract class AggregateRoot : EntityBase, IAggregateRoot
{
    public ConcurrentQueue<object> LocalEvents { get; } = new();

    public void AddLocalEvent<TEvent>(TEvent eventData) where TEvent : IEvent
    {
        LocalEvents.Enqueue(eventData);
    }

    public bool GetLocalEvent(out object? @event)
    {
        LocalEvents.TryDequeue(out var eventData);

        @event = eventData;
        return @event is not null;
    }

    public void ClearLocalEvents()
    {
        LocalEvents.Clear();
    }
}