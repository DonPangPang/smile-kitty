using SmileKitty.EventBus.Event;

namespace SmileKitty.Domain.Shared.Events.DonationInRecords;

public class DonationInRecordAddEvent : IEvent
{
    public Guid Id { get; set; }
    public Guid DonationId { get; set; }
    public Guid? UserId { get; set; }
    public string? Description { get; set; }
    public decimal Amount { get; set; }
    public DateTime CreateTime { get; set; }
    public bool IsAnonymous { get; set; }
}