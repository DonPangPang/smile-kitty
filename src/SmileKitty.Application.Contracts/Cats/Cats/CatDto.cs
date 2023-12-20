using SmileKitty.Application.Contracts.Cats.CatBreeds;
using SmileKitty.Application.Contracts.Cats.CatColors;
using SmileKitty.Application.Contracts.Cats.CatTemperaments;
using SmileKitty.Application.Contracts.Resources;
using SmileKitty.Domain.Shared.Enums;
using SmileKitty.Domain.Shared.GeneralModel;
using SmileKitty.Infrastructure.Dto;

namespace SmileKitty.Application.Contracts.Cats.Cats;

public class CatDto : DtoBase
{
    public required string Name { get; set; }
    public Gender Gender { get; set; }
    public Guid? AvatarId { get; set; }
    public AvatarResourceDto? Avatar { get; set; }
    public float Weight { get; set; }
    public string? Description { get; set; }

    public bool IsDeleted { get; set; }

    public Guid? BreedId { get; set; }
    public CatBreedDto? Breed { get; set; }
    public Guid? ColorId { get; set; }
    public CatColorDto? Color { get; set; }

    public EyeColor? EyeColorObject { get; set; }

    public Dictionary<string, string> DynamicElementObject { get; set; } = new Dictionary<string, string>();
    public ICollection<CatTemperamentDto> Temperaments { get; set; } = new List<CatTemperamentDto>();

}