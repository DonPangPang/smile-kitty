using SmileKitty.EventBus.Event;

namespace SmileKitty.Domain.Shared.Events.DonationOutRecords;

public class DonationOutRecordAddEvent : IEvent
{
    public Guid? DonationId { get; set; }
    public Guid? UserId { get; set; }
    public string? Description { get; set; }
    public decimal Amount { get; set; }
    public DateTime CreateTime { get; set; }
}

public class DonationOutRecordAddByCatIdEvent : IEvent
{
    public Guid? CatId { get; set; }
    public Guid? UserId { get; set; }
    public string? Description { get; set; }
    public decimal Amount { get; set; }
    public DateTime CreateTime { get; set; }
}