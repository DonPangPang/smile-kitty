using SmileKitty.Application.Exceptions;
using SmileKitty.Domain.Cats;
using SmileKitty.Domain.Shared.Events.Cats.CatRescuedApplys;
using SmileKitty.EntityFrameworkCore.UnitOfWorks;
using SmileKitty.EventBus.Handler;

namespace SmileKitty.Application.Handlers.Cats.CatRescuedApplys;

public class CatRescuedApplyAddRescuedRecordEventHandler(IUnitOfWork<CatRescuedRecord> unitOfWork) : IEventHandler<CatRescuedApplyAddRescuedRecordEvent>
{
    private readonly IUnitOfWork<CatRescuedRecord> _unitOfWork = unitOfWork;
    public async Task HandleAsync(CatRescuedApplyAddRescuedRecordEvent @event)
    {
        await _unitOfWork.InsertAsync(new CatRescuedRecord
        {
            CatId = @event.CatId,
            UserId = @event.UserId,
            HandlerId = @event.HandlerId,
            Description = @event.Description,
            Address = @event.RescuedAddress
        });
    }

    public void ExceptionHandle(Exception ex, CatRescuedApplyAddRescuedRecordEvent @event)
    {
        throw new HandlerException($"{nameof(CatRescuedApplyAddRescuedRecordEventHandler)}", ex);
    }
}