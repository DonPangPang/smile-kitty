using SmileKitty.EventBus.Event;

namespace SmileKitty.Domain.Shared.Events.LoginLogs;

public class LoginLogAddEvent : IEvent
{
    public Guid Id { get; set; }
    public Guid UserAuthorizationId { get; set; }
    public required string Ip { get; set; }
    public required string IpAddress { get; set; }
    public required string UserAgent { get; set; }
    public DateTime CreateTime { get; set; }
}