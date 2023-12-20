using SmileKitty.Domain.Resources;
using SmileKitty.Domain.Users;
using SmileKitty.Infrastructure.Entity;

namespace SmileKitty.Domain.Cats;

public class CatPost : AggregateRoot, IEntity, ICreation, IModification, IRecorder
{
    public Guid CatId { get; set; }
    public Cat? Cat { get; set; }

    public required string Content { get; set; }

    public ICollection<ImageResource> Images = new List<ImageResource>();

    public DateTime CreateTime { get; set; }
    public DateTime? ModifyTime { get; set; }

    public Guid CreationUserId { get; set; }
    public User? CreationUser { get; set; }
    public Guid? ModifyUserId { get; set; }
    public User? ModifyUser { get; set; }
}