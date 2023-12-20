using SmileKitty.Domain.Shared.Events.FileResources;

namespace SmileKitty.Domain.Resources;

public class ImageResource : Resource
{
    public required int Width { get; set; }
    public required int Height { get; set; }
}