using SmileKitty.Infrastructure.Entity;

namespace SmileKitty.Domain.Cats;

public class CatColor : AggregateRoot, IEntity, ICreationTime, IModificationTime, ISafeDelete
{
    public required string Name { get; set; }
    public string? Code { get; set; }
    public string? Description { get; set; }
    public DateTime CreateTime { get; set; }
    public DateTime? ModifyTime { get; set; }
    public bool IsDeleted { get; set; }
}