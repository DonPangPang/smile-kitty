using SmileKitty.Application.Contracts.Users.Users;
using SmileKitty.Infrastructure.Dto;
using SmileKitty.Infrastructure.QueryParameter;

namespace SmileKitty.Application.Contracts.Resources;

public abstract class ResourceDto : DtoBase
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? Url { get; set; }
    public string? Path { get; set; }
    public string? Extension { get; set; }
    public string? MimeType { get; set; }
    public long? Size { get; set; }
    public Guid CreationUserId { get; set; }
    public UserDto? Creation { get; set; }
}

public abstract class ResourceAddDto : IDto
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? Url { get; set; }
    public string? Path { get; set; }
    public string? Extension { get; set; }
    public string? MimeType { get; set; }
    public long? Size { get; set; }
}

public abstract class ResourceUpdateDto : DtoBase
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? Url { get; set; }
    public string? Path { get; set; }
    public string? Extension { get; set; }
    public string? MimeType { get; set; }
    public long? Size { get; set; }
}

public class ResourceQueryParameter : IQueryParameter, IPaging, IOrdering, ITimeRage
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Url { get; set; }
    public string? Path { get; set; }
    public string? Extension { get; set; }
    public string? MimeType { get; set; }
    public Guid? CreationUserId { get; set; }
    public int? PageIndex { get; set; }
    public int? PageSize { get; set; }
    public string? OrderBy { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
}