using SmileKitty.Domain.Shared.Events.FileResources;

namespace SmileKitty.Domain.Resources;

public class ImageResource : Resource
{
    public required int Width { get; set; }
    public required int Height { get; set; }

    public void CreateResource(string name, int width, int height, string? description, string? url, string? path, string? extension, string? mimeType,
        long? size)
    {
        Name = name;
        Description = description;
        Url = url;
        Path = path;
        Extension = extension;
        MimeType = mimeType;
        Size = size;
        CreateTime = DateTime.Now;

        AddLocalEvent(new ImageResourceAddEvent()
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

    /// <summary>
    /// Default Width and Height is 256 * 256
    /// </summary>
    /// <param name="name"></param>
    /// <param name="description"></param>
    /// <param name="url"></param>
    /// <param name="path"></param>
    /// <param name="extension"></param>
    /// <param name="mimeType"></param>
    /// <param name="size"></param>
    public override void CreateResource(string name, string? description, string? url, string? path, string? extension, string? mimeType,
        long? size)
    {
        CreateResource(name, 256, 256, description, url, path, extension, mimeType, size);
    }
}