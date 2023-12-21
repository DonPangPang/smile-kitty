using SmileKitty.Domain.Shared.Enums;
using SmileKitty.Domain.Shared.Events.Donations.DonationOutRecords;
using SmileKitty.Domain.Users;
using SmileKitty.Infrastructure.Entity;

namespace SmileKitty.Domain.Cats;

public class CatSalvage : AggregateRoot, IEntity, ICreationTime, IModificationTime, IReadOnly
{
    public Guid CatId { get; set; }
    public Cat? Cat { get; set; }
    public Guid UserId { get; set; }
    public User? User { get; set; }
    public string? Description { get; set; }

    public Guid CatSalvageTypeId { get; set; }
    public CatSalvageType? CatSalvageType { get; set; }

    public CatSalvageTypeChannel Channel { get; set; }
    public decimal Amount { get; set; }

    public DateTime CreateTime { get; set; }
    public DateTime? ModifyTime { get; set; }


    public void Cost()
    {
        if (Channel == CatSalvageTypeChannel.Donate)
        {
            return;
        }

        AddLocalEvent(new DonationOutRecordAddEvent()
        {
            CatId = Channel == CatSalvageTypeChannel.PrivateAccount ? CatId : null,
            Amount = Amount,
            UserId = UserId,
            Description = Description,
            CreateTime = DateTime.Now
        });
    }
}