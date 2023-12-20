using SmileKitty.Domain.Shared.Events.Users.UserAuthorizations;
using SmileKitty.Infrastructure.Entity;
using System.Text.Json.Serialization;

namespace SmileKitty.Domain.Users;

public class UserAuthorization
    : AggregateRoot, ISafeDelete, IEntity, ICreationTime, IModificationTime, IEnable
{
    public required string Account { get; set; }
    public required string Password { get; set; }
    public bool IsDeleted { get; set; } = false;
    public bool IsEnable { get; set; } = true;
    public DateTime CreateTime { get; set; }
    public DateTime? ModifyTime { get; set; }

    public Guid? UserId { get; set; }
    public User? User { get; set; }

    [JsonIgnore] public bool IsSuper { get; set; } = false;

    public void ChangePassword(string password)
    {
        Password = password;

        AddLocalEvent(new UserAuthorizationChangePasswordEvent()
        {
            UserAuthorizationId = Id,
            Password = Password
        });
    }

    public void Login()
    {
        AddLocalEvent(new UserAuthorizationLoginEvent()
        {
            UserAuthorizationId = Id,
            LoginTime = DateTime.Now
        });
    }
}