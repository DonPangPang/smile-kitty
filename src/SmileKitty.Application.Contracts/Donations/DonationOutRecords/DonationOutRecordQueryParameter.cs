using SmileKitty.Infrastructure.QueryParameter;

namespace SmileKitty.Application.Contracts.Donations.DonationOutRecords;

public class DonationOutRecordQueryParameter : IQueryParameter, IPaging, IOrdering, ITimeRage
{
    public Guid? UserId { get; set; }
    public Guid DonationId { get; set; }
    public int? PageIndex { get; set; }
    public int? PageSize { get; set; }
    public string? OrderBy { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
}