using SmileKitty.Domain.Shared.Enums;
using SmileKitty.Infrastructure.Dto;

namespace SmileKitty.Application.Contracts.Cats.CatSalvages;

public class CatSalvageAddDto : IDto
{
    public Guid CatId { get; set; }
    public Guid UserId { get; set; }
    public string? Description { get; set; }
    public Guid CatSalvageTypeId { get; set; }
    public CatSalvageTypeChannel Channel { get; set; }
    public decimal Amount { get; set; }
}