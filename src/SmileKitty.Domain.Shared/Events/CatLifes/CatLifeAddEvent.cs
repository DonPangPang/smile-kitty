using SmileKitty.EventBus.Event;

namespace SmileKitty.Domain.Shared.Events.CatLifes;

public class CatLifeAddEvent : IEvent
{
    public Guid Id { get; set; }
    public Guid CatId { get; set; }
    public string? Description { get; set; }
    public DateTime CreateTime { get; set; }
}