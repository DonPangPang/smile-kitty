using SmileKitty.Domain.Shared.Enums;
using SmileKitty.EventBus.Event;

namespace SmileKitty.Domain.Shared.Events.Cats;

public class CatAddEvent : IEvent
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public Gender Gender { get; set; }
    public Guid? AvatarId { get; set; }
    public float Weight { get; set; }
    public string? Description { get; set; }
    public Guid? DonationId { get; set; }
    public Guid? CatLifeId { get; set; }
    public DateTime CreateTime { get; set; }
    public bool IsDeleted { get; set; }
    public Guid? BreedId { get; set; }
    public Guid? ColorId { get; set; }
    public string? EyeColorString { get; set; }
    public string? DynamicElement { get; set; }
    public ICollection<Guid> TemperamentIds { get; set; } = new List<Guid>();
}

public class CatAddDonationEvent : IEvent
{
    public Guid Id { get; set; }
    public Guid DonationId { get; set; }
}

public class CatAddCatLife : IEvent
{
    public Guid Id { get; set; }
    public Guid CatLifeId { get; set; }
}

public class CatUpdateEvent : IEvent
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public Gender Gender { get; set; }
    public Guid? AvatarId { get; set; }
    public float Weight { get; set; }
    public string? Description { get; set; }
    public Guid? BreedId { get; set; }
    public Guid? ColorId { get; set; }
    public string? EyeColorString { get; set; }
    public string? DynamicElement { get; set; }
    public DateTime ModifyTime { get; set; }
    public ICollection<Guid> TemperamentIds { get; set; } = new List<Guid>();
}