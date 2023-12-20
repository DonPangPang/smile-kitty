using SmileKitty.Infrastructure.Dto;

namespace SmileKitty.Application.Contracts.Cats.CatBreeds;

public class CatBreedDto : DtoBase
{
    public required string Name { get; set; }
    public string? Description { get; set; }

    public DateTime CreateTime { get; set; }
}