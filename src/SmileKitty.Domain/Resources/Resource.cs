using SmileKitty.Domain.Shared.Events.FileResources;
using SmileKitty.Domain.Users;
using SmileKitty.Infrastructure.Entity;

namespace SmileKitty.Domain.Resources;

public abstract class Resource : EntityBase, IEntity, ICreation
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? Url { get; set; }
    public string? Path { get; set; }
    public string? Extension { get; set; }
    public string? MimeType { get; set; }
    public long? Size { get; set; }

    public DateTime CreateTime { get; set; }

    public Guid CreationUserId { get; set; }
    public User? Creation { get; set; }
}