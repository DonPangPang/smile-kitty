using SmileKitty.Application.Exceptions;
using SmileKitty.Domain.Cats;
using SmileKitty.Domain.Shared.Events.Cats.CatAdoptionApplys;
using SmileKitty.EntityFrameworkCore.UnitOfWorks;
using SmileKitty.EventBus.Handler;

namespace SmileKitty.Application.Handlers.Cats.CatAdoptionApplys;

public class CatAdoptionApplyAddAdoptionRecordEventHandler(IUnitOfWork<CatAdoptionRecord> unitOfWork) : IEventHandler<CatAdoptionApplyAddAdoptionRecordEvent>
{
    private readonly IUnitOfWork<CatAdoptionRecord> _unitOfWork = unitOfWork;
    public async Task HandleAsync(CatAdoptionApplyAddAdoptionRecordEvent @event)
    {
        await _unitOfWork.InsertAsync(new CatAdoptionRecord
        {
            CatId = @event.CatId,
            UserId = @event.UserId,
            HandlerId = @event.HandlerId,
            Description = @event.Description,
        });
    }

    public void ExceptionHandle(Exception ex, CatAdoptionApplyAddAdoptionRecordEvent @event)
    {
        throw new HandlerException($"{nameof(CatAdoptionApplyAddAdoptionRecordEventHandler)}", ex);
    }
}