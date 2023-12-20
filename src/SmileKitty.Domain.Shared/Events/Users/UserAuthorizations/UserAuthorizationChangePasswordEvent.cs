using SmileKitty.EventBus.Event;

namespace SmileKitty.Domain.Shared.Events.Users.UserAuthorizations;

public class UserAuthorizationChangePasswordEvent : IEvent
{
    public Guid UserAuthorizationId { get; set; }
    public required string Password { get; set; }
}

public class UserAuthorizationLoginEvent : IEvent
{
    public Guid UserAuthorizationId { get; set; }
    public DateTime LoginTime { get; set; }
}