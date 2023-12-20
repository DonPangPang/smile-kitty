using SmileKitty.Domain.Users;
using SmileKitty.Infrastructure.Entity;

namespace SmileKitty.Domain.Logs;

public class HistoryLog : EntityBase, ICreationTime, IReadOnly
{
    public Guid LinkId { get; set; }

    public required string Module { get; set; }

    public required string Data { get; set; }

    public Guid UserId { get; set; }
    public User? User { get; set; }

    public DateTime CreateTime { get; set; }
}