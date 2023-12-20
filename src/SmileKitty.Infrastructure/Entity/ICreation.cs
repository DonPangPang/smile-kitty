namespace SmileKitty.Infrastructure.Entity;

public interface ICreationTime
{
    public DateTime CreateTime { get; set; }
}

public interface ICreation : ICreationTime
{
    public Guid CreationUserId { get; set; }
}