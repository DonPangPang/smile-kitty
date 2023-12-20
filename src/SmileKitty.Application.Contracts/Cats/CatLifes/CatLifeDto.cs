using SmileKitty.Application.Contracts.Cats.CatAdoptionRecords;
using SmileKitty.Application.Contracts.Cats.CatRescuedRecords;
using SmileKitty.Application.Contracts.Cats.Cats;
using SmileKitty.Application.Contracts.Cats.CatSalvages;
using SmileKitty.Infrastructure.Dto;

namespace SmileKitty.Application.Contracts.Cats.CatLifes;

public class CatLifeDto : DtoBase
{
    public Guid CatId { get; set; }
    public CatDto? Cat { get; set; }
    public string? Description { get; set; }

    public Guid? CatRescuedRecordId { get; set; }
    public CatRescuedRecordDto? CatRescuedRecord { get; set; }

    public ICollection<CatSalvageDto> SalvageRecord { get; set; } = new List<CatSalvageDto>();
    public ICollection<CatAdoptionRecordDto> AdoptionRecords { get; set; } = new List<CatAdoptionRecordDto>();

    public DateTime CreateTime { get; set; }
    public DateTime? ModifyTime { get; set; }
}