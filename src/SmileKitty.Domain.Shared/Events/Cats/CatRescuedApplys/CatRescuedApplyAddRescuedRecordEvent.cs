using SmileKitty.EventBus.Event;

namespace SmileKitty.Domain.Shared.Events.Cats.CatRescuedApplys;

public class CatRescuedApplyAddRescuedRecordEvent : IEvent
{
    public Guid CatId { get; set; }
    public Guid UserId { get; set; }
    public Guid HandlerId { get; set; }
    public string? Description { get; set; }
    public string? RescuedAddress { get; set; }
}