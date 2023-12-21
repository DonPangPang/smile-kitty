using Microsoft.EntityFrameworkCore;
using SmileKitty.Application.Exceptions;
using SmileKitty.Domain.Cats;
using SmileKitty.Domain.Shared.Events.Cats.Cats;
using SmileKitty.EntityFrameworkCore.UnitOfWorks;
using SmileKitty.EventBus.Handler;

namespace SmileKitty.Application.Handlers.Cats.Cats;

public class CatStatusChangeEventHandler(IUnitOfWork<Cat> unitOfWork) : IEventHandler<CatStatusChangeEvent>
{
    private readonly IUnitOfWork<Cat> _unitOfWork = unitOfWork;
    public async Task HandleAsync(CatStatusChangeEvent @event)
    {
        var cat = await _unitOfWork.Queryable.Where(x => x.Id == @event.CatId).FirstOrDefaultAsync();
        if (cat is null) throw new ArgumentNullException(nameof(cat));

        cat.Status = @event.Status;

        await _unitOfWork.UpdateAsync(cat);
    }

    public void ExceptionHandle(Exception ex, CatStatusChangeEvent @event)
    {
        throw new HandlerException($"{nameof(CatStatusChangeEventHandler)}", ex);
    }
}