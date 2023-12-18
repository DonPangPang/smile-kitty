using SmileKitty.EventBus.Event;

namespace SmileKitty.EventBus.Handler;

public interface IEventHandler
{

}

public interface IEventHandler<in TEvent> : IEventHandler where TEvent : IEvent
{
    Task HandleAsync(TEvent @event);

    void ExceptionHandle(Exception ex, TEvent @event);
}