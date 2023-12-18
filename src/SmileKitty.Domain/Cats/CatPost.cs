using SmileKitty.Domain.Resources;
using SmileKitty.Domain.Users;
using SmileKitty.Infrastructure.Entity;

namespace SmileKitty.Domain.Cats;

public class CatPost : AggregateRootBase, IEntity, ICreation, IModification
{
    public Guid CatId { get; set; }
    public Cat? Cat { get; set; }

    public required string Content { get; set; }

    public ICollection<ImageResource> Images = new List<ImageResource>();

    public DateTime CreateTime { get; private set; }
    public DateTime? ModifyTime { get; private set; }

    public Guid UserId { get; set; }
    public User? User { get; set; }
}