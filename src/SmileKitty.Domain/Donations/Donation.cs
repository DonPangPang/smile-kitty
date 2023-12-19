using SmileKitty.Domain.Cats;
using SmileKitty.Domain.Shared.Enums;
using SmileKitty.Domain.Shared.Events.Donations;
using SmileKitty.Infrastructure.Entity;
using System.ComponentModel.DataAnnotations;

namespace SmileKitty.Domain.Donations;

public class Donation : AggregateRoot, IEntity, ICreation, IModification, IForbidDeleted
{
    public decimal Amount { get; set; }
    public DonationType DonationType { get; set; }

    public Guid? CatId { get; set; }
    public Cat? Cat { get; set; }

    public DateTime CreateTime { get; set; }
    public DateTime? ModifyTime { get; set; }


    [Timestamp]
    public byte[] Version { get; set; } = null!;


    public void CreateDonation(decimal amount, DonationType donationType, Cat? cat = null)
    {
        Amount = amount;
        DonationType = donationType;
        CatId = cat?.Id;
        Cat = cat;

        CreateTime = DateTime.Now;

        AddLocalEvent(new DonationAddEvent()
        {
            Id = Id,
            Amount = Amount,
            DonationType = DonationType,
            CatId = CatId,
            CreateTime = CreateTime,
        });
    }

    public void UpdateDonation(decimal amount, DonationType donationType, Cat? cat = null)
    {
        Amount = amount;
        DonationType = donationType;
        CatId = cat?.Id;
        Cat = cat;

        ModifyTime = DateTime.Now;

        AddLocalEvent(new DonationUpdateEvent()
        {
            Id = Id,
            Amount = Amount,
            DonationType = DonationType,
            CatId = CatId,
            ModifyTime = ModifyTime,
            Version = Version,
        });
    }

    public void UpdateDonationAmount(decimal amount)
    {
        ModifyTime = DateTime.Now;
        AddLocalEvent(new DonationUpdateAmountEvent()
        {
            Id = Id,
            Amount = amount,
        });
    }

    public void PlusDonationAmount(decimal amount)
    {
        Amount += amount;
        ModifyTime = DateTime.Now;
        AddLocalEvent(new DonationPlusAmountEvent()
        {
            Id = Id,
            Amount = amount,
            Version = Version,
        });
    }

    public void ReduceDonationAmount(decimal amount)
    {
        Amount -= amount;
        ModifyTime = DateTime.Now;
        AddLocalEvent(new DonationReduceAmountEvent()
        {
            Id = Id,
            Amount = amount,
            Version = Version,
        });
    }
}