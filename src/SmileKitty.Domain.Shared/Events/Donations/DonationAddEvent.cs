using SmileKitty.Domain.Shared.Enums;
using SmileKitty.EventBus.Event;

namespace SmileKitty.Domain.Shared.Events.Donations;

public class DonationAddEvent : IEvent
{
    public Guid Id { get; set; }
    public DonationType DonationType { get; set; }
    public decimal Amount { get; set; }
    public Guid? CatId { get; set; }
    public DateTime CreateTime { get; set; }
}

public class DonationPlusAmountEvent : IEvent
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
    public byte[] Version { get; set; } = null!;
}


public class DonationReduceAmountEvent : IEvent
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
    public byte[] Version { get; set; } = null!;
}