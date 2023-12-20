using SmileKitty.Domain.Shared.Events.Donations;
using SmileKitty.Domain.Users;
using SmileKitty.Infrastructure.Entity;

namespace SmileKitty.Domain.Donations;

public class DonationInRecord : AggregateRoot, IEntity, ICreationTime, IReadOnly, IForbidDeleted, IAnonymous
{
    public Guid? UserId { get; set; }
    public User? User { get; set; }
    public Guid DonationId { get; set; }
    public Donation? Donation { get; set; }
    public string? Description { get; set; }

    public decimal Amount { get; set; }

    public DateTime CreateTime { get; set; }

    public bool IsAnonymous { get; set; }

    public void CreateDonationInRecord(Donation donation, decimal amount, User? user = null, string? description = null)
    {
        UserId = user?.Id;
        User = user;
        DonationId = donation.Id;
        Description = description;
        Amount = amount;

        CreateTime = DateTime.Now;

        AddLocalEvent(new DonationInRecordAddEvent()
        {
            Id = Id,
            DonationId = DonationId,
            UserId = UserId,
            Description = Description,
            Amount = Amount,
            CreateTime = CreateTime,
            IsAnonymous = IsAnonymous,
        });

        AddLocalEvent(new DonationPlusAmountEvent()
        {
            Id = DonationId,
            Amount = Amount,
            Version = donation.Version,
        });
    }
}