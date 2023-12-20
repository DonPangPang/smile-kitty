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

    public DateTime CreateTime { get; protected set; }

    public virtual void CreateResource(string name, string? description, string? url, string? path, string? extension,
        string? mimeType, long? size)
    {
        Name = name;
        Description = description;
        Url = url;
        Path = path;
        Extension = extension;
        MimeType = mimeType;
        Size = size;
        CreateTime = DateTime.Now;

        AddLocalEvent(new ResourceAddEvent
        {
            Id = Id,
            Name = Name,
            Description = Description,
            Url = Url,
            Path = Path,
            Extension = Extension,
            MimeType = MimeType,
            Size = Size,
            CreateTime = CreateTime
        });
    }

    public virtual void DeleteResource()
    {
        AddLocalEvent(new ResourceDeleteEvent
        {
            Id = Id
        });
    }
}