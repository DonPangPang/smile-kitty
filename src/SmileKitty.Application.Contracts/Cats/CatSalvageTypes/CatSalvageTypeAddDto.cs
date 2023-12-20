using SmileKitty.Infrastructure.Dto;

namespace SmileKitty.Application.Contracts.Cats.CatSalvageTypes;

public class CatSalvageTypeAddDto : IDto
{
    public required string Name { get; set; }
    public string? Description { get; set; }
}