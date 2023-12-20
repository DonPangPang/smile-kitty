using SmileKitty.Infrastructure.Dto;

namespace SmileKitty.Application.Contracts.Cats.CatTemperaments;

public class CatTemperamentAddDto : IDto
{
    public required string Name { get; set; }
    public string? Description { get; set; }
}