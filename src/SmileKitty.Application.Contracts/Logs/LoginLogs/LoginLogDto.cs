using SmileKitty.Application.Contracts.Users.UserAuthorizations;
using SmileKitty.Infrastructure.Dto;

namespace SmileKitty.Application.Contracts.Logs.LoginLogs;

public class LoginLogDto:DtoBase
{
    public Guid UserAuthorizationId { get; set; }
    public UserAuthorizationDto? UserAuthorization { get; set; }

    public required string Ip { get; set; }
    public required string IpAddress { get; set; }
    public required string UserAgent { get; set; }

    public DateTime CreateTime { get; set; }
}