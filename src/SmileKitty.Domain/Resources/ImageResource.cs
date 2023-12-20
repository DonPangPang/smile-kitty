using SmileKitty.Domain.Shared.Events.FileResources;

namespace SmileKitty.Domain.Resources;

public class ImageResource : Resource
{
    public int Width { get; set; }
    public int Height { get; set; }
}