using SmileKitty.Application.Contracts.Cats.Cats;
using SmileKitty.Application.Contracts.Cats.CatSalvageTypes;
using SmileKitty.Application.Contracts.Users.Users;
using SmileKitty.Domain.Shared.Enums;
using SmileKitty.Infrastructure.Dto;

namespace SmileKitty.Application.Contracts.Cats.CatSalvages;

public class CatSalvageDto : DtoBase
{
    public Guid CatId { get; set; }
    public CatDto? Cat { get; set; }
    public Guid UserId { get; set; }
    public UserDto? User { get; set; }
    public string? Description { get; set; }

    public CatSalvageTypeChannel Channel { get; set; }
    public decimal Amount { get; set; }

    public Guid CatSalvageTypeId { get; set; }
    public CatSalvageTypeDto? CatSalvageType { get; set; }

    public DateTime CreateTime { get; set; }
    public DateTime? ModifyTime { get; set; }
}