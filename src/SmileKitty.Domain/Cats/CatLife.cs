using SmileKitty.Infrastructure.Entity;

namespace SmileKitty.Domain.Cats;

public class CatLife : AggregateRootBase, IEntity, ICreation, IModification, ISafeDelete
{
    public Guid CatId { get; set; }
    public Cat? Cat { get; set; }
    public string? Description { get; set; }

    public Guid CatRescuedRecordId { get; set; }
    public CatRescuedRecord? CatRescuedRecord { get; set; }

    public ICollection<CatSalvageRecord> SalvageRecord { get; set; } = new List<CatSalvageRecord>();
    public ICollection<CatAdoptionRecord> AdoptionRecords { get; set; } = new List<CatAdoptionRecord>();

    public DateTime CreateTime { get; private set; }
    public DateTime? ModifyTime { get; private set; }
    public bool IsDeleted { get; private set; }
}