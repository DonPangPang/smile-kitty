using SmileKitty.Domain.Shared.Enums;
using SmileKitty.EventBus.Event;

namespace SmileKitty.Domain.Shared.Events.Users;

public class UserAddEvent : IEvent
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public Gender Gender { get; set; }
    public string? Phone { get; set; }
    public Guid? AvatarId { get; set; }
    public string? Description { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreateTime { get; set; }

    public Guid UserAuthorizationId { get; set; }
}