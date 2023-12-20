using SmileKitty.Application.Contracts.Cats.CatAdoptionRecords;
using SmileKitty.Application.Contracts.Cats.Cats;
using SmileKitty.Application.Contracts.Users.Users;
using SmileKitty.Infrastructure.Dto;

namespace SmileKitty.Application.Contracts.Cats.CatAdoptReturnRecords;

public class CatAdoptReturnRecordDto : DtoBase
{
    public Guid CatId { get; set; }
    public CatDto? Cat { get; set; }
    public Guid UserId { get; set; }
    public UserDto? User { get; set; }
    public string? Description { get; set; }

    public Guid CatAdoptionRecordId { get; set; }
    public CatAdoptionRecordDto? CatAdoptionRecord { get; set; }

    public DateTime CreateTime { get; set; }
    public DateTime? ModifyTime { get; set; }
}