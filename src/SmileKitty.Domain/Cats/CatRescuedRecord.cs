using SmileKitty.Domain.Users;
using SmileKitty.Infrastructure.Entity;

namespace SmileKitty.Domain.Cats;

public class CatRescuedRecord : AggregateRoot, IEntity, ICreation, IModification, ISafeDelete
{
    public Guid CatId { get; set; }
    public Cat? Cat { get; set; }
    public ICollection<User> Users { get; set; } = new List<User>();
    public string? Description { get; set; }

    public string? Address { get; set; }

    public DateTime CreateTime { get; set; }
    public DateTime? ModifyTime { get; set; }
    public bool IsDeleted { get; set; }
}