using SmileKitty.Domain.Shared.Events.CatLifes;
using SmileKitty.Infrastructure.Entity;

namespace SmileKitty.Domain.Cats;

public class CatLife : AggregateRoot, IEntity, ICreation, IModification
{
    public Guid CatId { get; set; }
    public Cat? Cat { get; set; }
    public string? Description { get; set; }

    public Guid? CatRescuedRecordId { get; set; }
    public CatRescuedRecord? CatRescuedRecord { get; set; }

    public ICollection<CatSalvageRecord> SalvageRecord { get; set; } = new List<CatSalvageRecord>();
    public ICollection<CatAdoptionRecord> AdoptionRecords { get; set; } = new List<CatAdoptionRecord>();

    public DateTime CreateTime { get; set; }
    public DateTime? ModifyTime { get; set; }

    public void CreateCatLift(Cat cat)
    {
        CatId = cat.Id;
        Cat = cat;

        CreateTime = DateTime.Now;

        AddLocalEvent(new CatLifeAddEvent()
        {
            Id = Id,
            CatId = CatId,
            CreateTime = CreateTime,
        });
    }
}