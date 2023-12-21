using SmileKitty.Domain.Shared.Enums;
using SmileKitty.EventBus.Event;

namespace SmileKitty.Domain.Shared.Events.Cats.Cats;

public class CatStatusChangeEvent : IEvent
{
    public required Guid CatId { get; set; }
    public required CatStatus Status { get; set; }
}