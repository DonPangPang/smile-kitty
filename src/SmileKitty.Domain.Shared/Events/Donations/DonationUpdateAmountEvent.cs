using SmileKitty.EventBus.Event;

namespace SmileKitty.Domain.Shared.Events.Donations;

public class DonationUpdateAmountEvent : IEvent
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
}