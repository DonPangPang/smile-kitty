using SmileKitty.Domain.Shared.Events.FileResources;
using SmileKitty.Infrastructure.Entity;

namespace SmileKitty.Domain.Resources;

public abstract class Resource : AggregateRoot, IEntity, ICreationTime
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? Url { get; set; }
    public string? Path { get; set; }
    public string? Extension { get; set; }
    public string? MimeType { get; set; }
    public long? Size { get; set; }

    public DateTime CreateTime { get; set; }
}