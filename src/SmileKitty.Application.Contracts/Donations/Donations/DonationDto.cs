using SmileKitty.Application.Contracts.Cats.Cats;
using SmileKitty.Domain.Shared.Enums;
using SmileKitty.Infrastructure.Dto;

namespace SmileKitty.Application.Contracts.Donations.Donations;

public class DonationDto : DtoBase
{
    public decimal Amount { get; set; }
    public DonationType DonationType { get; set; }

    public Guid? CatId { get; set; }
    public CatDto? Cat { get; set; }

    public DateTime CreateTime { get; set; }
    public DateTime? ModifyTime { get; set; }
}