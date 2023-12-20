using SmileKitty.Domain.Donations;
using SmileKitty.Domain.Resources;
using SmileKitty.Domain.Shared.Enums;
using SmileKitty.Domain.Shared.GeneralModel;
using SmileKitty.Infrastructure.Common;
using SmileKitty.Infrastructure.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmileKitty.Domain.Cats;

public class Cat : EntityBase, IEntity, ICreationTime, IModificationTime, ISafeDelete, IRecorder
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

    public string? DynamicElement { get; set; }

    [NotMapped]
    public Dictionary<string, string> DynamicElementObject
    {
        get => (string.IsNullOrWhiteSpace(DynamicElement) ? null : DynamicElement.ToObject<Dictionary<string, string>>()) ?? new Dictionary<string, string>();

        set => DynamicElement = value.ToJson();
    }

    public ICollection<CatTemperament> Temperaments { get; set; } = new List<CatTemperament>();

    public ICollection<CatPost> Posts { get; set; } = new List<CatPost>();

    public CatStatus Status { get; set; } = CatStatus.Stray;

    [Timestamp]
    public byte[]? RowVersion { get; set; }


    public void CreateLife()
    {
        CatLife = new CatLife
        {
            Cat = this,
            CatId = Id
        };

        CatLifeId = CatLife.Id;
    }

    public void CreateDonation()
    {
        Donation = new Donation
        {
            Cat = this,
            CatId = Id,
            DonationType = DonationType.Cat,
            Amount = 0
        };

        DonationId = Donation.Id;
    }
}