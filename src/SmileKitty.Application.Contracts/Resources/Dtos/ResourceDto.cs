using SmileKitty.Infrastructure.Dto;

namespace SmileKitty.Application.Contracts.Resources.Dtos;

public abstract class ResourceDto : DtoBase
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? Url { get; set; }
    public string? Path { get; set; }
    public string? Extension { get; set; }
    public string? MimeType { get; set; }
    public long? Size { get; set; }
}

public class ImageResourceDto : ResourceDto
{
    public int Width { get; set; }
    public int Height { get; set; }
}

public class FileResourceDto : ResourceDto
{

}

public class AvatarResourceDto : ImageResourceDto
{

}