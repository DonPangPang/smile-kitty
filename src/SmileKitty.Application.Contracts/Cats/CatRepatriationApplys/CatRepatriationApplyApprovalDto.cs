using SmileKitty.Domain.Shared.Enums;

namespace SmileKitty.Application.Contracts.Cats.CatRepatriationApplys;

public class CatRepatriationApplyApprovalDto
{
    public Guid Id { get; set; }
    public FlowResult Result { get; set; }
}