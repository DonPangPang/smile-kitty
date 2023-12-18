using Microsoft.Extensions.DependencyInjection;
using SmileKitty.EventBus.Event;
using SmileKitty.EventBus.Handler;
using System.Threading.Channels;

namespace SmileKitty.EventBus.Core;

public class LocalEventManager<TEvent>(IServiceProvider servicesProvider)
    : ILocalEventManager<TEvent> where TEvent : IEvent
{
    private readonly IServiceProvider _servicesProvider = servicesProvider;

    private readonly Channel<TEvent> _eventChannel = Channel.CreateUnbounded<TEvent>();

    public CancellationTokenSource Cts { get; } = new CancellationTokenSource();

    public CancellationTokenSource Cancel()
    {
        throw new NotImplementedException();
    }

    public async Task PubAsync(TEvent @event)
    {
        await _eventChannel.Writer.WriteAsync(@event);
    }

    public void OnSub()
    {
        Task.Run(async () =>
        {
            while (!Cts.IsCancellationRequested)
            {
                var reader = await _eventChannel.Reader.ReadAsync(Cts.Token);
                await Handle(reader);
            }
        });
    }

    private async Task Handle(TEvent @event)
    {
        var handler = _servicesProvider.GetService<IEventHandler<TEvent>>();

        if (handler is null)
        {
            throw new NullReferenceException($"No handler for event {@event.GetType().Name}");
        }
        try
        {
            await handler.HandleAsync(@event);
        }
        catch (Exception ex)
        {
            handler.ExceptionHandle(ex, @event);
        }
    }
}