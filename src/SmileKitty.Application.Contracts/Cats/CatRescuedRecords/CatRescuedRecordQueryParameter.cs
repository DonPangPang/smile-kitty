using SmileKitty.Infrastructure.QueryParameter;

namespace SmileKitty.Application.Contracts.Cats.CatRescuedRecords;

public class CatRescuedRecordQueryParameter : IQueryParameter, IOrdering, IPaging, ITimeRage
{
    public Guid? CatId { get; set; }
    public Guid? UserId { get; set; }
    public string? Address { get; set; }
    public Guid? HandlerId { get; set; }
    public string? OrderBy { get; set; }
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
}