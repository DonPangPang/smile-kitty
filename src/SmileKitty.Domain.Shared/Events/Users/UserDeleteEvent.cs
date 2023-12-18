using SmileKitty.EventBus.Event;

namespace SmileKitty.Domain.Shared.Events.Users;

public class UserDeleteEvent : IEvent
{
    public Guid Id { get; set; }
    public bool IsDeleted { get; set; }
}