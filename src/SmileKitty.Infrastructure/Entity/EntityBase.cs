namespace SmileKitty.Infrastructure.Entity;

public abstract class EntityBase : IEntity
{
    public Guid Id
    {
        get;
        set;
    } = Guid.NewGuid();
}