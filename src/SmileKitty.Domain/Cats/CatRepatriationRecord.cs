using SmileKitty.Domain.Users;
using SmileKitty.Infrastructure.Entity;

namespace SmileKitty.Domain.Cats;

public class CatRepatriationRecord : AggregateRoot, IEntity, ICreationTime, IModificationTime, ISafeDelete
{
    public Guid CatId { get; set; }
    public Cat? Cat { get; set; }
    public Guid UserId { get; set; }
    public User? User { get; set; }
    public string? Description { get; set; }

    public DateTime CreateTime { get; set; }
    public DateTime? ModifyTime { get; set; }
    public bool IsDeleted { get; set; }

    public Guid HandlerId { get; set; }
    public User? Handler { get; set; }
}