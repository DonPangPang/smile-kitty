using SmileKitty.Domain.Users;
using SmileKitty.Infrastructure.Entity;

namespace SmileKitty.Domain.Cats;

public class CatRescuedRecord : AggregateRootBase, IEntity, ICreation, IModification, ISafeDelete
{
    public Guid CatId { get; set; }
    public Cat? Cat { get; set; }
    public ICollection<User> Users { get; set; } = new List<User>();
    public string? Description { get; set; }

    public string? Address { get; set; }

    public DateTime CreateTime { get; private set; }
    public DateTime? ModifyTime { get; private set; }
    public bool IsDeleted { get; private set; }
}