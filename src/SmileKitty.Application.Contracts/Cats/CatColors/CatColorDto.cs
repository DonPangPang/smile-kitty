using SmileKitty.Infrastructure.Dto;

namespace SmileKitty.Application.Contracts.Cats.CatColors;

public class CatColorDto : DtoBase
{
    public required string Name { get; set; }
    public string? Code { get; set; }
    public string? Description { get; set; }
    public DateTime CreateTime { get; set; }
}