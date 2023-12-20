using SmileKitty.Domain.Shared.Enums;
using SmileKitty.Infrastructure.QueryParameter;

namespace SmileKitty.Application.Contracts.Cats.CatSalvages;

public class CatSalvageQueryParameter : IQueryParameter, IOrdering, IPaging, ITimeRage
{
    public Guid? CatSalvageTypeId { get; set; }
    public CatSalvageTypeChannel? Channel { get; set; }
    public Guid? CatId { get; set; }
    public Guid? UserId { get; set; }
    public string? OrderBy { get; set; }
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
}