namespace SmileKitty.Infrastructure.QueryParameter;

public interface IQueryParameter
{

}

public interface IPaging
{
    int PageIndex { get; set; }
    int PageSize { get; set; }
}

public interface IOrdering
{
    string? OrderBy { get; set; }
}