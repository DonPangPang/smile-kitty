using SmileKitty.EventBus.Event;

namespace SmileKitty.Domain.Shared.Events.UserAuthorizations;

public class UserAuthorizationDeleteEvent : IEvent
{
    public Guid Id { get; set; }
    public bool IsDeleted { get; set; }
}