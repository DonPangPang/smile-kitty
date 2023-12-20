using SmileKitty.Infrastructure.QueryParameter;

namespace SmileKitty.Application.Contracts.Cats.CatRepatriationRecords;

public class CatRepatriationRecordQueryParameter : IQueryParameter, IOrdering, IPaging, ITimeRage
{
    public Guid? CatId { get; set; }
    public Guid? UserId { get; set; }
    public string? OrderBy { get; set; }
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
}