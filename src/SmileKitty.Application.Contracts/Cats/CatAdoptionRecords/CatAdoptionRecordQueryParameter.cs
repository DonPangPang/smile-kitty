using SmileKitty.Infrastructure.QueryParameter;

namespace SmileKitty.Application.Contracts.Cats.CatAdoptionRecords;

public class CatAdoptionRecordQueryParameter : IQueryParameter, IPaging, IOrdering, ITimeRage
{
    public Guid? CatId { get; set; }
    public string? OrderBy { get; set; }
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
}