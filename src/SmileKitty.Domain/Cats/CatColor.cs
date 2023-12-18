using SmileKitty.Infrastructure.Entity;

namespace SmileKitty.Domain.Cats;

public class CatColor : AggregateRootBase, IEntity, ICreation, IModification, ISafeDelete
{
    public required string Name { get; set; }
    public string? Code { get; set; }
    public string? Description { get; set; }
    public DateTime CreateTime { get; private set; }
    public DateTime? ModifyTime { get; private set; }
    public bool IsDeleted { get; private set; }
}