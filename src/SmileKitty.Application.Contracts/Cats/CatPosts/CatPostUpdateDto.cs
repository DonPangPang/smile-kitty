using SmileKitty.Application.Contracts.Resources.Dtos;
using SmileKitty.Infrastructure.Dto;

namespace SmileKitty.Application.Contracts.Cats.CatPosts;

public class CatPostUpdateDto : DtoBase
{
    public Guid CatId { get; set; }

    public required string Content { get; set; }

    public ICollection<ImageResourceUpdateDto> Images = new List<ImageResourceUpdateDto>();
}