using Microsoft.Extensions.DependencyInjection;
using SmileKitty.EventBus.Handler;
using SmileKitty.Infrastructure.Entity;

namespace SmileKitty.EntityFrameworkCore.UnitOfWorks;

public class UnitOfWork<TEntity>(
    SmileKittyDbContext dbContext
    , IServiceProvider serviceProvider) : IUnitOfWork<TEntity> where TEntity : class, IEntity
{
    private readonly SmileKittyDbContext _dbContext = dbContext;

    public IQueryable<TEntity> Queryable => _dbContext.Set<TEntity>().AsQueryable();

    private async Task HandleLocalEventsAsync(TEntity entity)
    {
        if (entity is AggregateRoot aggregateRoot)
        {
            while (aggregateRoot.GetLocalEvent(out var @event))
            {
                if (@event is null) break;

                var handlerType = typeof(IEventHandler<>).MakeGenericType(@event.GetType());
                var handler = serviceProvider.GetRequiredService(handlerType);

                var handleMethod = handlerType.GetMethod("HandleAsync");
                var exceptionHandleMethod = handlerType.GetMethod("ExceptionHandle");

                try
                {
                    await (Task)handleMethod!.Invoke(handler, new[] { @event })!;
                }
                catch (Exception ex)
                {
                    exceptionHandleMethod!.Invoke(handler, new[] { ex, @event });
                }
            }

            aggregateRoot.ClearLocalEvents();
        }
    }

    public async Task<bool> CommitAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await HandleLocalEventsAsync(entity);

        return await _dbContext.SaveChangesAsync(cancellationToken) > 0;
    }
}