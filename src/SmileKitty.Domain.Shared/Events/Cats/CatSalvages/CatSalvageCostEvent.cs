using SmileKitty.EventBus.Event;

namespace SmileKitty.Domain.Shared.Events.Cats.CatSalvages;

public class CatSalvageCostEvent : IEvent
{
    public Guid CatId { get; set; }
    public decimal Cost { get; set; }
}