using SmileKitty.EventBus.Event;

namespace SmileKitty.Domain.Shared.Events.Cats.CatAdoptionApplys;

public class CatAdoptionApplyAddAdoptionRecordEvent : IEvent
{
    public Guid CatId { get; set; }
    public Guid UserId { get; set; }
    public Guid HandlerId { get; set; }
    public string? Description { get; set; }
}