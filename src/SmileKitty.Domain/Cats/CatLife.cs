using SmileKitty.Infrastructure.Entity;

namespace SmileKitty.Domain.Cats;

public class CatLife : AggregateRoot, IEntity, ICreationTime, IModificationTime
{
    public Guid CatId { get; set; }
    public Cat? Cat { get; set; }
    public string? Description { get; set; }

    public Guid? CatRescuedRecordId { get; set; }
    public CatRescuedRecord? CatRescuedRecord { get; set; }

    public ICollection<CatSalvage> SalvageRecord { get; set; } = new List<CatSalvage>();
    public ICollection<CatAdoptionRecord> AdoptionRecords { get; set; } = new List<CatAdoptionRecord>();

    public DateTime CreateTime { get; set; }
    public DateTime? ModifyTime { get; set; }

}