using SmileKitty.Domain.Shared.Events.Donations;
using SmileKitty.Domain.Users;
using SmileKitty.Infrastructure.Entity;

namespace SmileKitty.Domain.Donations;

public class DonationOutRecord : AggregateRoot, IEntity, ICreationTime, IReadOnly, IForbidDeleted
{
    public Guid? UserId { get; set; }
    public User? User { get; set; }
    public Guid DonationId { get; set; }
    public Donation? Donation { get; set; }
    public string? Description { get; set; }

    public decimal Amount { get; set; }

    public DateTime CreateTime { get; set; }
    public bool IsDeleted { get; set; }
}