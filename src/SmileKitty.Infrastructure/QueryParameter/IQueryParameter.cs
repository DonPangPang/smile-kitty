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

public interface ITimeRage
{
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
}