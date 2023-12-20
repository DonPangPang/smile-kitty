using SmileKitty.Domain.Resources;
using SmileKitty.Domain.Shared.Enums;
using SmileKitty.Infrastructure.Entity;

namespace SmileKitty.Domain.Users;

public class User : AggregateRoot, ISafeDelete, IEntity, ICreationTime, IModificationTime
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public Gender Gender { get; set; }
    public string? Phone { get; set; }
    public Guid? AvatarId { get; set; }
    public AvatarResource? Avatar { get; set; }
    public string? Description { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreateTime { get; set; }
    public DateTime? ModifyTime { get; set; }

    public Guid UserAuthorizationId { get; set; }
    public UserAuthorization? UserAuthorization { get; set; }
}