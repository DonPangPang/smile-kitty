using SmileKitty.Domain.Shared.Enums;
using SmileKitty.Domain.Shared.Events.Users;
using SmileKitty.Infrastructure.Entity;

namespace SmileKitty.Domain.Users;

public class User : AggregateRootBase, ISafeDelete, IEntity, ICreation, IModification
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public Gender Gender { get; set; }
    public string? Phone { get; set; }
    public string? Avatar { get; set; }
    public string? Description { get; private set; }
    public bool IsDeleted { get; private set; }
    public DateTime CreateTime { get; private set; }
    public DateTime? ModifyTime { get; private set; }

    public Guid UserAuthorizationId { get; private set; }
    public UserAuthorization? UserAuthorization { get; private set; }

    public void CreateUser(UserAuthorization userAuthorization)
    {
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
            Avatar = Avatar,
            Description = Description,
            CreateTime = CreateTime,
            UserAuthorizationId = UserAuthorizationId,

            IsDeleted = IsDeleted
        });
    }

    public void UpdateUser(string name, string email, string? phone = null, string? avatar = null, string? description = null)
    {
        Name = name;
        Email = email;
        Gender = Gender;
        Phone = phone;
        Avatar = avatar;
        Description = description;

        ModifyTime = DateTime.Now;

        AddLocalEvent(new UserUpdateEvent()
        {
            Id = Id,
            Name = Name,
            Email = Email,
            Phone = Phone,
            Avatar = Avatar,
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