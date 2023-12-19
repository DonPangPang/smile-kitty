using SmileKitty.Infrastructure.Entity;

namespace SmileKitty.EntityFrameworkCore.UnitOfWorks;

public interface IUnitOfWork<TEntity> where TEntity : class, IEntity
{
    IQueryable<TEntity> Queryable { get; }

    //Task InsertAsync(TEntity entity);
    //Task UpdateAsync(TEntity entity);
    //Task DeleteAsync(TEntity entity);
    Task<bool> CommitAsync(TEntity entity, CancellationToken cancellationToken = default);
}