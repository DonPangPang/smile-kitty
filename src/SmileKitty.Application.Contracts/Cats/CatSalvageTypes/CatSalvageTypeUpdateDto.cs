using SmileKitty.Infrastructure.Dto;

namespace SmileKitty.Application.Contracts.Cats.CatSalvageTypes;

public class CatSalvageTypeUpdateDto : DtoBase
{
    public required string Name { get; set; }
    public string? Description { get; set; }
}