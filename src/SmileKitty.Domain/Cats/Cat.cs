using SmileKitty.Domain.Donations;
using SmileKitty.Domain.Shared.Enums;
using SmileKitty.Infrastructure.Common;
using SmileKitty.Infrastructure.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmileKitty.Domain.Cats;

public class Cat : AggregateRootBase, IEntity, ICreation, IModification, ISafeDelete
{
    public required string Name { get; set; }
    public Gender Gender { get; set; }
    public string? Avatar { get; set; }
    public float Weight { get; set; }
    public string? Description { get; set; }

    public Guid? DonationId { get; set; }
    public Donation? Donation { get; set; }

    public Guid? CatLifeId { get; set; }
    public CatLife? CatLife { get; set; }

    public DateTime CreateTime { get; private set; }
    public DateTime? ModifyTime { get; private set; }
    public bool IsDeleted { get; private set; }


    public Guid BreedId { get; private set; }
    public CatBreed? Breed { get; private set; }
    public Guid ColorId { get; set; }
    public CatColor? Color { get; set; }

    public string? EyeColorString { get; private set; }

    [NotMapped]
    public EyeColor? EyeColorObject
    {
        get => string.IsNullOrWhiteSpace(EyeColorString) ? null : EyeColorString.ToObject<EyeColor>();

        set => EyeColorString = value?.ToJson();
    }

    public class EyeColor
    {
        public string? Left { get; set; }
        public string? Right { get; set; }
    }

    public string? DynamicElement { get; private set; }

    [NotMapped]
    public Dictionary<string, string> DynamicElementObject
    {
        get => (string.IsNullOrWhiteSpace(DynamicElement) ? null : DynamicElement.ToObject<Dictionary<string, string>>()) ?? new Dictionary<string, string>();

        set => DynamicElement = value.ToJson();
    }

    public ICollection<CatTemperament> Temperaments { get; set; } = new List<CatTemperament>();

    public ICollection<CatPost> Posts { get; set; } = new List<CatPost>();
}