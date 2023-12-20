using SmileKitty.Infrastructure.QueryParameter;

namespace SmileKitty.Application.Contracts.Cats.CatSalvageTypes;

public class CatSalvageTypeQueryParameter : IQueryParameter, IOrdering, IPaging
{
    public string? Name { get; set; }
    public string? OrderBy { get; set; }
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
}