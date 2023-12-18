using SmileKitty.EventBus.Event;

namespace SmileKitty.Domain.Shared.Events.UserAuthorizations;

public class UserAuthorizationBindUserEvent : IEvent
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
}