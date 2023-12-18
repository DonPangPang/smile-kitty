using SmileKitty.Domain.Shared.Enums;
using SmileKitty.Infrastructure.Entity;

namespace SmileKitty.Domain.Cats;

public class CatSalvageType : AggregateRootBase, IEntity, ICreation, IModification, ISafeDelete
{
    public required string Name { get; set; }
    public string? Description { get; set; }

    public CatSalvageTypeChannel Channel { get; set; }
    public decimal Price { get; set; }

    public DateTime CreateTime { get; private set; }
    public DateTime? ModifyTime { get; private set; }
    public bool IsDeleted { get; private set; }
}