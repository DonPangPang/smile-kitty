using SmileKitty.Infrastructure.Dto;

namespace SmileKitty.Application.Contracts.Cats.CatSalvageTypes;

public class CatSalvageTypeDto : DtoBase
{
    public required string Name { get; set; }
    public string? Description { get; set; }

    public DateTime CreateTime { get; set; }
}