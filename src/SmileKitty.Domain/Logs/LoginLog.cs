using SmileKitty.Domain.Shared.Events.LoginLogs;
using SmileKitty.Domain.Users;
using SmileKitty.Infrastructure.Entity;

namespace SmileKitty.Domain.Logs;

public class LoginLog : AggregateRoot, IEntity, ICreationTime
{
    public Guid UserAuthorizationId { get; set; }
    public UserAuthorization? UserAuthorization { get; set; }

    public required string Ip { get; set; }
    public required string IpAddress { get; set; }
    public required string UserAgent { get; set; }

    public DateTime CreateTime { get; set; }


    public void CreateLoginLog()
    {
        CreateTime = DateTime.Now;

        AddLocalEvent(new LoginLogAddEvent()
        {
            Id = Id,
            UserAuthorizationId = UserAuthorizationId,
            Ip = Ip,
            IpAddress = IpAddress,
            UserAgent = UserAgent,
            CreateTime = CreateTime,
        });
    }
}
