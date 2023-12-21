using SmileKitty.Domain.Shared.Enums;
using SmileKitty.Domain.Shared.GeneralModel;
using SmileKitty.Infrastructure.QueryParameter;

namespace SmileKitty.Application.Contracts.Cats.Cats;

public class CatQueryParameter : IQueryParameter, IPaging, IOrdering, ITimeRage
{
    public string? Name { get; set; }
    public Gender? Gender { get; set; }

    public float? MinWeight { get; set; }
    public float? MaxWeight { get; set; }

    public Guid? DonationId { get; set; }

    public Guid? CatLifeId { get; set; }


    public Guid? BreedId { get; set; }
    public Guid? ColorId { get; set; }

    public EyeColor? EyeColorObject { get; set; }

    public Guid[]? Temperaments { get; set; }
    public int? PageIndex { get; set; }
    public int? PageSize { get; set; }
    public string? OrderBy { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
}