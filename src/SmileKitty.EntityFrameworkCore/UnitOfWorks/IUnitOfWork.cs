using SmileKitty.Infrastructure.Entity;

namespace SmileKitty.EntityFrameworkCore.UnitOfWorks;

public interface IUnitOfWork<TEntity> where TEntity : class, IEntity
{
    IQueryable<TEntity> Queryable { get; }
    Task InsertAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task InsertAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task UpdateAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
    Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
    Task<bool> CommitAsync(CancellationToken cancellationToken = default);
}