using SmileKitty.Domain.Shared.Events.UserAuthorizations;
using SmileKitty.Infrastructure.Entity;
using System.Text.Json.Serialization;

namespace SmileKitty.Domain.Users;

public class UserAuthorization
    : AggregateRoot, ISafeDelete, IEntity, ICreation, IModification, IEnable
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

    public UserAuthorization(string account, string password, User? user = null, bool isSuper = false)
    {
        Account = account;
        Password = password;
        UserId = user?.Id;
        User = user;

        IsSuper = isSuper;
    }

    public void CreateUserAuthorization()
    {
        CreateTime = DateTime.Now;


        AddLocalEvent(new UserAuthorizationAddEvent()
        {
            Id = Id,
            Account = Account,
            Password = Password,
            UserId = UserId,
            CreateTime = CreateTime,
            IsSuper = IsSuper,
            IsDeleted = IsDeleted,
            IsEnable = IsEnable,
        });
    }

    public void UpdateUserAuthorization(string account, string password, bool isEnable, bool isSuper)
    {
        Account = account;
        Password = password;
        IsEnable = isEnable;
        IsSuper = isSuper;

        ModifyTime = DateTime.Now;

        AddLocalEvent(new UserAuthorizationUpdateEvent()
        {
            Id = Id,
            Account = Account,
            Password = Password,
            IsSuper = IsSuper,
            ModifyTime = ModifyTime,
        });
    }

    public void DeleteUserAuthorization()
    {
        IsDeleted = true;

        AddLocalEvent(new UserAuthorizationDeleteEvent()
        {
            Id = Id,
            IsDeleted = IsDeleted,
        });
    }

    public void EnableUserAuthorization(bool isEnable)
    {
        IsEnable = isEnable;

        AddLocalEvent(new UserAuthorizationEnableEvent()
        {
            Id = Id,
            IsEnable = IsEnable,
        });
    }

    public void UpdateUserAuthorizationPassword(string password)
    {
        Password = password;

        AddLocalEvent(new UserAuthorizationUpdatePasswordEvent()
        {
            Id = Id,
            Password = Password,
        });
    }

    public void BindUser(User user)
    {
        UserId = user.Id;
        User = user;

        AddLocalEvent(new UserAuthorizationBindUserEvent()
        {
            Id = Id,
            UserId = UserId.Value,
        });
    }
}