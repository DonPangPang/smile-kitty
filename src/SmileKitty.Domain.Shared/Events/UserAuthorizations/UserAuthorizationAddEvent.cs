using SmileKitty.EventBus.Event;

namespace SmileKitty.Domain.Shared.Events.UserAuthorizations;

public class UserAuthorizationAddEvent : IEvent
{
    public Guid Id { get; set; }
    public required string Account { get; set; }
    public required string Password { get; set; }
    public Guid? UserId { get; set; }
    public bool IsSuper { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsEnable { get; set; }
    public DateTime CreateTime { get; set; }
}