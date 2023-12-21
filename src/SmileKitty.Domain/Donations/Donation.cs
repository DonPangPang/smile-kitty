using SmileKitty.Domain.Cats;
using SmileKitty.Domain.Shared.Enums;
using SmileKitty.Infrastructure.Entity;
using System.ComponentModel.DataAnnotations;

namespace SmileKitty.Domain.Donations;

public class Donation : AggregateRoot, IEntity, ICreationTime, IModificationTime, IForbidDeleted, IRecorder
{
    public decimal Amount { get; set; }
    public DonationType DonationType { get; set; }

    public Guid? CatId { get; set; }
    public Cat? Cat { get; set; }

    public DateTime CreateTime { get; set; }
    public DateTime? ModifyTime { get; set; }


    [Timestamp]
    public byte[] Version { get; set; } = null!;
}