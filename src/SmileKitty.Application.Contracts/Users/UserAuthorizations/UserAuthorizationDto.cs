using SmileKitty.Application.Contracts.Users.Users;
using SmileKitty.Infrastructure.Dto;

namespace SmileKitty.Application.Contracts.Users.UserAuthorizations;

public class UserAuthorizationDto : DtoBase
{
    public required string Account { get; set; }
    public required string Password { get; set; }
    public bool IsDeleted { get; set; } = false;
    public bool IsEnable { get; set; } = true;
    public DateTime CreateTime { get; set; }
    public DateTime? ModifyTime { get; set; }

    public Guid? UserId { get; set; }
    public UserDto? User { get; set; }
}