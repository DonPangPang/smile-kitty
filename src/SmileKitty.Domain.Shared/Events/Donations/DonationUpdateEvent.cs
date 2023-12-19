using SmileKitty.Domain.Shared.Enums;
using SmileKitty.EventBus.Event;

namespace SmileKitty.Domain.Shared.Events.Donations;

public class DonationUpdateEvent : IEvent
{
    public Guid Id { get; set; }
    public DonationType DonationType { get; set; }
    public decimal Amount { get; set; }
    public Guid? CatId { get; set; }
    public DateTime? ModifyTime { get; set; }

    public byte[] Version { get; set; } = null!;
}