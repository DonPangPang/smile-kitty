using SmileKitty.EventBus.Event;

namespace SmileKitty.Domain.Shared.Events.UserAuthorizations;

public class UserAuthorizationEnableEvent : IEvent
{
    public Guid Id { get; set; }
    public bool IsEnable { get; set; }
}