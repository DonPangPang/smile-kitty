using SmileKitty.Domain.Donations;
using SmileKitty.Domain.Resources;
using SmileKitty.Domain.Shared.Enums;
using SmileKitty.Domain.Shared.Events.Cats;
using SmileKitty.Infrastructure.Common;
using SmileKitty.Infrastructure.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmileKitty.Domain.Cats;

public class Cat : AggregateRoot, IEntity, ICreation, IModification, ISafeDelete
{
    public required string Name { get; set; }
    public Gender Gender { get; set; }
    public Guid? AvatarId { get; set; }
    public AvatarResource? Avatar { get; set; }
    public float Weight { get; set; }
    public string? Description { get; set; }

    public Guid? DonationId { get; set; }
    public Donation? Donation { get; set; }

    public Guid? CatLifeId { get; set; }
    public CatLife? CatLife { get; set; }

    public DateTime CreateTime { get; set; }
    public DateTime? ModifyTime { get; set; }
    public bool IsDeleted { get; set; }


    public Guid? BreedId { get; set; }
    public CatBreed? Breed { get; set; }
    public Guid? ColorId { get; set; }
    public CatColor? Color { get; set; }

    public string? EyeColorString { get; set; }

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

    public string? DynamicElement { get; set; }

    [NotMapped]
    public Dictionary<string, string> DynamicElementObject
    {
        get => (string.IsNullOrWhiteSpace(DynamicElement) ? null : DynamicElement.ToObject<Dictionary<string, string>>()) ?? new Dictionary<string, string>();

        set => DynamicElement = value.ToJson();
    }

    public ICollection<CatTemperament> Temperaments { get; set; } = new List<CatTemperament>();

    public ICollection<CatPost> Posts { get; set; } = new List<CatPost>();

    public void CreateCat(
        string name,
        Gender gender,
        AvatarResource avatar,
        float weight,
        string? description,
        CatBreed? breed,
        CatColor? color,
        EyeColor? eyeColor,
        Dictionary<string, string>? dynamicElement,
        List<CatTemperament> catTemperaments)
    {
        Name = name;
        Gender = gender;
        Avatar = avatar;
        Weight = weight;
        Description = description;
        BreedId = breed?.Id;
        Breed = breed;
        ColorId = color?.Id;
        Color = color;
        EyeColorObject = eyeColor;
        DynamicElementObject = dynamicElement ?? new Dictionary<string, string>();
        Temperaments = catTemperaments;

        CreateTime = DateTime.Now;

        AddLocalEvent(new CatAddEvent()
        {
            Id = Id,
            Name = Name,
            Gender = gender,
            AvatarId = AvatarId,
            Weight = Weight,
            Description = Description,
            BreedId = BreedId,
            ColorId = ColorId,
            EyeColorString = EyeColorString,
            DynamicElement = DynamicElement,
            TemperamentIds = Temperaments.Select(x => x.Id).ToList()
        });

        Donation = new Donation();
        Donation.CreateDonation(0, DonationType.Cat, this);
        DonationId = Donation.Id;

        AddLocalEvent(new CatAddDonationEvent()
        {
            Id = Id,
            DonationId = Donation.Id
        });

        CatLife = new CatLife();
        CatLife.CreateCatLift(this);
        CatLifeId = CatLife.Id;

        AddLocalEvent(new CatAddCatLife()
        {
            Id = Id,
            CatLifeId = CatLife.Id
        });
    }
}