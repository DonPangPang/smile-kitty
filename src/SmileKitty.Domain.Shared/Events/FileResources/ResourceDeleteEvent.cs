using SmileKitty.EventBus.Event;

namespace SmileKitty.Domain.Shared.Events.FileResources;

public class ResourceDeleteEvent : IEvent
{
    public Guid Id { get; set; }
}