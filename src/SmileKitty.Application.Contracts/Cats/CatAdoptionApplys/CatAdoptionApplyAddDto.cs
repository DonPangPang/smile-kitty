namespace SmileKitty.Application.Contracts.Cats.CatAdoptionApplys;

public class CatAdoptionApplyAddDto
{
    public Guid CatId { get; set; }
    public Guid UserId { get; set; }
    public string? Description { get; set; }
}