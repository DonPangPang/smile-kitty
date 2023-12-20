namespace SmileKitty.Application.Contracts.Resources.Dtos;

public class ImageResourceDto : ResourceDto
{
    public int Width { get; set; }
    public int Height { get; set; }
}

public class ImageResourceAddDto : ResourceAddDto
{
    public int Width { get; set; }
    public int Height { get; set; }
}

public class ImageResourceUpdateDto : ResourceUpdateDto
{
    public int Width { get; set; }
    public int Height { get; set; }
}