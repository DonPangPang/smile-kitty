namespace SmileKitty.Infrastructure.Entity;

public interface ISafeDelete
{
    public bool IsDeleted { get; set; }
}