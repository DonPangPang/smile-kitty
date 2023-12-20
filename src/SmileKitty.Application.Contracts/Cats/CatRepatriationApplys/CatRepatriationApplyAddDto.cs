namespace SmileKitty.Application.Contracts.Cats.CatRepatriationApplys;

public class CatRepatriationApplyAddDto
{
    public Guid CatId { get; set; }
    public Guid UserId { get; set; }
    public string? Description { get; set; }
}