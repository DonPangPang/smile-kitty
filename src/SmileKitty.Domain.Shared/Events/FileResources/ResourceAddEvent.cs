using SmileKitty.EventBus.Event;

namespace SmileKitty.Domain.Shared.Events.FileResources;

public class ResourceAddEvent : IEvent
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? Url { get; set; }
    public string? Path { get; set; }
    public string? Extension { get; set; }
    public string? MimeType { get; set; }
    public long? Size { get; set; }
    public DateTime CreateTime { get; set; }
}