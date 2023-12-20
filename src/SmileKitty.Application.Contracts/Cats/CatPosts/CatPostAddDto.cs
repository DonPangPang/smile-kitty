using SmileKitty.Application.Contracts.Resources.Dtos;
using SmileKitty.Infrastructure.Dto;

namespace SmileKitty.Application.Contracts.Cats.CatPosts;

public class CatPostAddDto : IDto
{
    public Guid CatId { get; set; }

    public required string Content { get; set; }

    public ICollection<ImageResourceAddDto> Images = new List<ImageResourceAddDto>();
}