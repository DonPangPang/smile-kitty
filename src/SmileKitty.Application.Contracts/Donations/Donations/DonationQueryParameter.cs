using SmileKitty.Domain.Shared.Enums;
using SmileKitty.Infrastructure.QueryParameter;

namespace SmileKitty.Application.Contracts.Donations.Donations;

public class DonationQueryParameter : IQueryParameter, IPaging, IOrdering, ITimeRage
{
    public DonationType? DonationType { get; set; }

    public Guid? CatId { get; set; }

    public decimal? MaxAmount { get; set; }
    public decimal? MinAmount { get; set; }

    public int? PageIndex { get; set; }
    public int? PageSize { get; set; }
    public string? OrderBy { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
}