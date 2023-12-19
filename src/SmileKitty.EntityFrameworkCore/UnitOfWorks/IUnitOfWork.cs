using SmileKitty.Infrastructure.Entity;

namespace SmileKitty.EntityFrameworkCore.UnitOfWorks;

public interface IUnitOfWork<TEntity> where TEntity : class, IEntity
{
    IQueryable<TEntity> Queryable { get; }
    Task<bool> CommitAsync(TEntity entity, CancellationToken cancellationToken = default);
}