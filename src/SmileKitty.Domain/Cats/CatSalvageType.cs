using SmileKitty.Domain.Shared.Enums;
using SmileKitty.Infrastructure.Entity;

namespace SmileKitty.Domain.Cats;

public class CatSalvageType : AggregateRoot, IEntity, ICreation, IModification, ISafeDelete
{
    public required string Name { get; set; }
    public string? Description { get; set; }

    public CatSalvageTypeChannel Channel { get; set; }
    public decimal Price { get; set; }

    public DateTime CreateTime { get; set; }
    public DateTime? ModifyTime { get; set; }
    public bool IsDeleted { get; set; }
}