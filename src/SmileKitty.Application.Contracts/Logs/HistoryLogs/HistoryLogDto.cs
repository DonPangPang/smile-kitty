using SmileKitty.Application.Contracts.Users.Users;
using SmileKitty.Infrastructure.Dto;

namespace SmileKitty.Application.Contracts.Logs.HistoryLogs;

public class HistoryLogDto : DtoBase
{
    public Guid LinkId { get; set; }
    public required string Module { get; set; }

    //public required string Data { get; set; }

    public Guid UserId { get; set; }
    public UserDto? User { get; set; }

    public DateTime CreateTime { get; set; }
}