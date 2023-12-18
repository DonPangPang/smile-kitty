using SmileKitty.Domain.Cats;
using SmileKitty.Domain.Shared.Enums;
using SmileKitty.Infrastructure.Entity;
using System.ComponentModel.DataAnnotations;

namespace SmileKitty.Domain.Donations;

public class Donation : AggregateRootBase, IEntity, ICreation, IModification, ISafeDelete
{
    public decimal Amount { get; private set; }
    public DonationType DonationType { get; set; }

    public Guid? CatId { get; set; }
    public Cat? Cat { get; set; }

    public DateTime CreateTime { get; private set; }
    public DateTime? ModifyTime { get; private set; }
    public bool IsDeleted { get; private set; }


    [Timestamp]
    public byte[] Version { get; set; } = null!;
}