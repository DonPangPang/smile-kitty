using SmileKitty.Infrastructure.Dto;

namespace SmileKitty.Application.Contracts.Cats.CatBreeds;

public class CatBreedAddDto : IDto
{
    public required string Name { get; set; }
    public string? Description { get; set; }
}