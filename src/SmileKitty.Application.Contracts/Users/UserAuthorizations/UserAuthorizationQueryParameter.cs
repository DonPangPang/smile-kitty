using SmileKitty.Infrastructure.QueryParameter;

namespace SmileKitty.Application.Contracts.Users.UserAuthorizations;

public class UserAuthorizationQueryParameter : IQueryParameter, IPaging, IOrdering
{
    public string? Account { get; set; }
    public DateTime CreateTime { get; private set; }

    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public string? OrderBy { get; set; }
}