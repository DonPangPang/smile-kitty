namespace SmileKitty.Application.Contracts.Cats.CatRescuedApplys;

public class CatRescuedApplyAddDto
{
    public Guid CatId { get; set; }
    public Guid UserId { get; set; }
    public string? Description { get; set; }

    public required string Address { get; set; }
}