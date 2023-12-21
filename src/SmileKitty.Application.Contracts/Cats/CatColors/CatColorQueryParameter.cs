using SmileKitty.Infrastructure.QueryParameter;

namespace SmileKitty.Application.Contracts.Cats.CatColors;

public class CatColorQueryParameter : IQueryParameter, IOrdering, IPaging
{
    public string? Name { get; set; }
    public string? OrderBy { get; set; }
    public int? PageIndex { get; set; }
    public int? PageSize { get; set; }
}