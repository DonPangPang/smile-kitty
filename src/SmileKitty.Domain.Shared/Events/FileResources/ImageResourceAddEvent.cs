namespace SmileKitty.Domain.Shared.Events.FileResources;

public class ImageResourceAddEvent : ResourceAddEvent
{
    public int Width { get; set; }
    public int Height { get; set; }
}