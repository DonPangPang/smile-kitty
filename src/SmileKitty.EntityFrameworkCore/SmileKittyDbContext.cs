using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.DependencyInjection;
using SmileKitty.Domain.Logs;
using SmileKitty.EntityFrameworkCore.Exceptions;
using SmileKitty.EventBus.Handler;
using SmileKitty.Infrastructure.Common;
using SmileKitty.Infrastructure.Entity;

namespace SmileKitty.EntityFrameworkCore;

public class SmileKittyDbContext(DbContextOptions<SmileKittyDbContext> options, IServiceProvider serviceProvider)
    : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entityEntry in ChangeTracker.Entries<IEntity>())
        {
            if (entityEntry is { Entity: IReadOnly, State: not (EntityState.Added and EntityState.Unchanged) })
            {
                throw new SmileKittyReadOnlyException();
            }

            if (entityEntry is { Entity: ICreation creation, State: EntityState.Added })
            {
                // TODO: 从登录信息中获取用户信息
                creation.CreationUserId = Guid.Empty;
            }

            if (entityEntry is { Entity: ICreationTime creationTime, State: EntityState.Added })
            {
                creationTime.CreateTime = DateTime.Now;
            }

            if (entityEntry is { Entity: IModification modification, State: EntityState.Modified })
            {
                // TODO: 从登录信息中获取用户信息
                modification.ModifyUserId = Guid.Empty;
            }

            if (entityEntry is { Entity: IModificationTime modificationTime, State: EntityState.Modified })
            {
                modificationTime.ModifyTime = DateTime.Now;
            }

            if (entityEntry is { Entity: ISafeDelete safeDelete, State: EntityState.Deleted })
            {
                safeDelete.IsDeleted = true;
                entityEntry.State = EntityState.Modified;
            }

            if (entityEntry.Entity is IRecorder recorder)
            {
                await Set<HistoryLog>().AddAsync(new HistoryLog()
                {
                    LinkId = entityEntry.Entity.Id,
                    Module = entityEntry.Entity.GetType().Name,
                    Data = recorder.ToJson().Compress(),
                    CreateTime = DateTime.Now
                }, cancellationToken);
            }

            if (entityEntry.Entity is IAggregateRoot aggregateRoot)
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

        return await base.SaveChangesAsync(cancellationToken);
    }

}