using SmileKitty.Domain.Users;
using SmileKitty.Infrastructure.Entity;

namespace SmileKitty.Domain.Cats;

public class CatAdoptionRecord : AggregateRootBase, IEntity, ICreation, IModification, ISafeDelete
{
    public Guid CatId { get; set; }
    public Cat? Cat { get; set; }
    public Guid UserId { get; set; }
    public User? User { get; set; }
    public string? Description { get; set; }

    public Guid? CatRepatriationRecordId { get; set; }
    public CatRepatriationRecord? CatRepatriationRecord { get; set; }

    public DateTime CreateTime { get; private set; }
    public DateTime? ModifyTime { get; private set; }
    public bool IsDeleted { get; private set; }

    public Guid HandlerId { get; set; }
    public User? Handler { get; set; }

    public ICollection<CatAdoptReturnRecord> CatAdoptReturnRecords { get; set; } = new List<CatAdoptReturnRecord>();
}