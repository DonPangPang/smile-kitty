using SmileKitty.Infrastructure.Dto;

namespace SmileKitty.Application.Contracts.Cats.CatColors;

public class CatColorAddDto : IDto
{
    public required string Name { get; set; }
    public string? Code { get; set; }
    public string? Description { get; set; }
}