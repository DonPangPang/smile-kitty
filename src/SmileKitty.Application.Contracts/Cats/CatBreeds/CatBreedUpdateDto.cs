using SmileKitty.Infrastructure.Dto;

namespace SmileKitty.Application.Contracts.Cats.CatBreeds;

public class CatBreedUpdateDto : DtoBase
{
    public required string Name { get; set; }
    public string? Description { get; set; }
}