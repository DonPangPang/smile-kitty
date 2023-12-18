using SmileKitty.EventBus.Event;
using System.Collections.Concurrent;

namespace SmileKitty.Infrastructure.Entity;

public interface IAggregateRoot : IEntity
{
    void AddLocalEvent<TEvent>(TEvent eventData) where TEvent : IEvent;
}

public abstract class AggregateRootBase : EntityBase, IAggregateRoot
{
    public ConcurrentQueue<object> LocalEvents { get; } = new();

    public void AddLocalEvent<TEvent>(TEvent eventData) where TEvent : IEvent
    {
        LocalEvents.Enqueue(eventData);
    }

    public object? GetLocalEvent()
    {
        return LocalEvents.TryDequeue(out var eventData) ? eventData : null;
    }

    public void ClearLocalEvents()
    {
        LocalEvents.Clear();
    }
}