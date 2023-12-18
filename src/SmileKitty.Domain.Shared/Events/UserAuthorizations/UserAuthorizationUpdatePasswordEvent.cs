using SmileKitty.EventBus.Event;

namespace SmileKitty.Domain.Shared.Events.UserAuthorizations;

public class UserAuthorizationUpdatePasswordEvent : IEvent
{
    public Guid Id { get; set; }
    public string Password { get; set; } = string.Empty;
}