using SmileKitty.Infrastructure.Dto;

namespace SmileKitty.Application.Contracts.Users.UserAuthorizations;

public class UserAuthorizationAddDto : DtoBase
{
    public required string Account { get; set; }
    public required string Password { get; set; }
}