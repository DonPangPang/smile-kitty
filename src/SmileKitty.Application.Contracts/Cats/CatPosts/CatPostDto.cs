using SmileKitty.Application.Contracts.Cats.Cats;
using SmileKitty.Application.Contracts.Resources;
using SmileKitty.Application.Contracts.Users.Users;
using SmileKitty.Infrastructure.Dto;

namespace SmileKitty.Application.Contracts.Cats.CatPosts;

public class CatPostDto : DtoBase
{
    public Guid CatId { get; set; }
    public CatDto? Cat { get; set; }

    public required string Content { get; set; }

    public ICollection<ImageResourceDto> Images = new List<ImageResourceDto>();

    public DateTime CreateTime { get; set; }
    public DateTime? ModifyTime { get; set; }

    public Guid CreationUserId { get; set; }
    public UserDto? CreationUser { get; set; }
    public Guid? ModifyUserId { get; set; }
    public UserDto? ModifyUser { get; set; }
}