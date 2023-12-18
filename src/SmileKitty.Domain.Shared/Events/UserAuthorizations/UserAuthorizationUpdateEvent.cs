using SmileKitty.EventBus.Event;

namespace SmileKitty.Domain.Shared.Events.UserAuthorizations;

public class UserAuthorizationUpdateEvent : IEvent
{
    public Guid Id { get; set; }
    public string Account { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public DateTime? ModifyTime { get; set; }
    public Guid? UserId { get; set; }
    public bool IsSuper { get; set; }
}