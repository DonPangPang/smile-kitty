using SmileKitty.Infrastructure.Dto;

namespace SmileKitty.Application.Contracts.Users.UserAuthorizations;

public class UserAuthorizationUpdateDto : DtoBase
{
    public required string OldPassword { get; set; }
    public required string NewPassword { get; set; }
}