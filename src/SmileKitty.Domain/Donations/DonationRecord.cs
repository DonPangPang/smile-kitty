using SmileKitty.Domain.Users;
using SmileKitty.Infrastructure.Entity;

namespace SmileKitty.Domain.Donations;

public class DonationRecord : AggregateRootBase, IEntity, ICreation, IReadOnly, ISafeDelete, IAnonymous
{
    public Guid? UserId { get; set; }
    public User? User { get; set; }
    public Guid DonationId { get; set; }
    public Donation? Donation { get; set; }
    public string? Description { get; set; }

    public decimal Amount { get; set; }

    public DateTime CreateTime { get; private set; }
    public bool IsDeleted { get; private set; }

    public bool IsAnonymous { get; set; }
}