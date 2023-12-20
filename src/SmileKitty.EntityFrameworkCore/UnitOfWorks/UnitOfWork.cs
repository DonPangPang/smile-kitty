using SmileKitty.Infrastructure.Entity;

namespace SmileKitty.EntityFrameworkCore.UnitOfWorks;

public class UnitOfWork<TEntity>(
    SmileKittyDbContext dbContext
    , IServiceProvider serviceProvider) : IUnitOfWork<TEntity> where TEntity : class, IEntity
{
    private readonly SmileKittyDbContext _dbContext = dbContext;

    public IQueryable<TEntity> Queryable => _dbContext.Set<TEntity>().AsQueryable();
    public async Task InsertAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await _dbContext.AddAsync(entity, cancellationToken);
    }

    public async Task InsertAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        await _dbContext.AddRangeAsync(entities, cancellationToken);
    }

    public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await Task.Run(() =>
        {
            _dbContext.Update(entity);
        }, cancellationToken);
    }

    public async Task UpdateAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        await Task.Run(() =>
        {
            _dbContext.UpdateRange(entities);
        }, cancellationToken);
    }

    public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await Task.Run(() =>
        {
            _dbContext.Remove(entity);
        }, cancellationToken);
    }

    public async Task DeleteAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        await Task.Run(() =>
        {
            _dbContext.RemoveRange(entities);
        }, cancellationToken);
    }

    public async Task<bool> CommitAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.SaveChangesAsync(cancellationToken) > 0;
    }
}