using SmileKitty.Domain.Shared.Enums;

namespace SmileKitty.Application.Contracts.Cats.CatAdoptionApplys;

public class CatAdoptionApplyApprovalDto
{
    public Guid Id { get; set; }
    public FlowResult Result { get; set; }
}