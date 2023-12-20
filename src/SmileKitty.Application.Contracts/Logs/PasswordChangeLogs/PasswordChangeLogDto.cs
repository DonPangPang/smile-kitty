using SmileKitty.Application.Contracts.Users.UserAuthorizations;
using SmileKitty.Infrastructure.Dto;

namespace SmileKitty.Application.Contracts.Logs.PasswordChangeLogs;

public class PasswordChangeLogDto : DtoBase
{
    public Guid UserAuthorizationId { get; set; }
    public UserAuthorizationDto? UserAuthorization { get; set; }

    public required string Ip { get; set; }
    public required string IpAddress { get; set; }
    public required string UserAgent { get; set; }

    public required string Password { get; set; }

    public DateTime CreateTime { get; set; }
}