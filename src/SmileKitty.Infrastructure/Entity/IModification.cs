namespace SmileKitty.Infrastructure.Entity;

public interface IModificationTime
{
    public DateTime? ModifyTime { get; set; }
}

public interface IModification
{
    public Guid? ModifyUserId { get; set; }
}
