using SmileKitty.Application.Contracts.Cats.Cats;
using SmileKitty.Application.Contracts.Users.Users;
using SmileKitty.Infrastructure.Dto;

namespace SmileKitty.Application.Contracts.Cats.CatRepatriationRecords;

public class CatRepatriationRecordDto : DtoBase
{
    public Guid CatId { get; set; }
    public CatDto? Cat { get; set; }
    public Guid UserId { get; set; }
    public UserDto? User { get; set; }
    public string? Description { get; set; }

    public DateTime CreateTime { get; set; }
}