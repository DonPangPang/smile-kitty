using SmileKitty.Domain.Resources;
using SmileKitty.Domain.Shared.Enums;
using SmileKitty.Domain.Shared.Events.Users;
using SmileKitty.Infrastructure.Entity;

namespace SmileKitty.Domain.Users;

public class User : AggregateRoot, ISafeDelete, IEntity, ICreation, IModification
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public Gender Gender { get; set; }
    public string? Phone { get; set; }
    public Guid? AvatarId { get; set; }
    public AvatarResource? Avatar { get; set; }
    public string? Description { get; set; }
    public bool IsDeleted { get; private set; }
    public DateTime CreateTime { get; private set; }
    public DateTime? ModifyTime { get; private set; }

    public Guid UserAuthorizationId { get; set; }
    public UserAuthorization? UserAuthorization { get; set; }

    public void CreateUser(UserAuthorization? userAuthorization)
    {
        if (userAuthorization is null) throw new ArgumentNullException(nameof(userAuthorization));

        CreateTime = DateTime.Now;
        UserAuthorizationId = userAuthorization.Id;
        UserAuthorization = userAuthorization;

        AddLocalEvent(new UserAddEvent()
        {
            Id = Id,
            Name = Name,
            Email = Email,
            Gender = Gender,
            Phone = Phone,
            Description = Description,
            CreateTime = CreateTime,
            UserAuthorizationId = UserAuthorizationId,

            IsDeleted = IsDeleted
        });
    }

    public void CreateUser()
    {
        CreateUser(UserAuthorization);
    }

    public void UpdateUser(string name, string email, string? phone = null, AvatarResource? avatar = null, string? description = null)
    {
        Name = name;
        Email = email;
        Gender = Gender;
        Phone = phone;
        AvatarId = avatar?.Id;
        Avatar = avatar;
        Description = description;

        ModifyTime = DateTime.Now;

        AddLocalEvent(new UserUpdateEvent()
        {
            Id = Id,
            Name = Name,
            Email = Email,
            Phone = Phone,
            AvatarId = AvatarId,
            Description = Description,
            ModifyTime = ModifyTime
        });
    }

    public void DeleteUser()
    {
        IsDeleted = true;

        AddLocalEvent(new UserDeleteEvent()
        {
            Id = Id,
            IsDeleted = IsDeleted
        });
    }
}