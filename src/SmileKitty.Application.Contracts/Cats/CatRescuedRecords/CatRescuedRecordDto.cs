using SmileKitty.Application.Contracts.Cats.Cats;
using SmileKitty.Application.Contracts.Users.Users;

namespace SmileKitty.Application.Contracts.Cats.CatRescuedRecords;

public class CatRescuedRecordDto
{
    public Guid CatId { get; set; }
    public CatDto? Cat { get; set; }
    public Guid UserId { get; set; }
    public UserDto? User { get; set; }
    public string? Description { get; set; }

    public required string Address { get; set; }

    public Guid HandlerId { get; set; }
    public UserDto? Handler { get; set; }

    public DateTime CreateTime { get; set; }
    public DateTime? ModifyTime { get; set; }
}