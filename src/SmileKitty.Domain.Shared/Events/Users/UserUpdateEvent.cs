using SmileKitty.Domain.Shared.Enums;
using SmileKitty.EventBus.Event;

namespace SmileKitty.Domain.Shared.Events.Users;

public class UserUpdateEvent : IEvent
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public Gender Gender { get; set; }
    public string? Phone { get; set; }
    public Guid? AvatarId { get; set; }
    public string? Description { get; set; }
    public DateTime? ModifyTime { get; set; }
}