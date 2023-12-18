using SmileKitty.Domain.Users;
using SmileKitty.Infrastructure.Entity;

namespace SmileKitty.Domain.Logs;

public class LoginLog : AggregateRootBase, IEntity, ICreation
{
    public Guid UserAuthorizationId { get; private set; }
    public UserAuthorization? UserAuthorization { get; private set; }

    public required string Ip { get; set; }
    public required string IpAddress { get; set; }
    public required string UserAgent { get; set; }

    public DateTime CreateTime { get; private set; }
}
