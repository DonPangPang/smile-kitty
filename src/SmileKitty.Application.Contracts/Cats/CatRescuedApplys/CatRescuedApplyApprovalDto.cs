using SmileKitty.Domain.Shared.Enums;

namespace SmileKitty.Application.Contracts.Cats.CatRescuedApplys;

public class CatRescuedApplyApprovalDto
{
    public Guid Id { get; set; }
    public FlowResult Result { get; set; }
}