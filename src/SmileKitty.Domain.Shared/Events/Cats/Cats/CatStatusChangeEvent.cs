using SmileKitty.Domain.Shared.Enums;
using SmileKitty.EventBus.Event;

namespace SmileKitty.Domain.Shared.Events.Cats.Cats;

public class CatStatusChangeEvent : IEvent
{
    public Guid CatId { get; set; }
    public CatStatus Status { get; set; }
}