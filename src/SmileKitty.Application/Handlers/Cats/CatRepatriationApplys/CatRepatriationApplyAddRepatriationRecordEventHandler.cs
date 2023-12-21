using SmileKitty.Application.Exceptions;
using SmileKitty.Domain.Cats;
using SmileKitty.Domain.Shared.Events.Cats.CatRepatriationApplys;
using SmileKitty.EntityFrameworkCore.UnitOfWorks;
using SmileKitty.EventBus.Handler;

namespace SmileKitty.Application.Handlers.Cats.CatRepatriationApplys;

public class CatRepatriationApplyAddRepatriationRecordEventHandler(IUnitOfWork<CatRepatriationRecord> unitOfWork) : IEventHandler<CatRepatriationApplyAddRepatriationRecordEvent>
{
    private readonly IUnitOfWork<CatRepatriationRecord> _unitOfWork = unitOfWork;

    public async Task HandleAsync(CatRepatriationApplyAddRepatriationRecordEvent @event)
    {
        await _unitOfWork.InsertAsync(new CatRepatriationRecord
        {
            CatId = @event.CatId,
            UserId = @event.UserId,
            HandlerId = @event.HandlerId,
            Description = @event.Description,
        });
    }

    public void ExceptionHandle(Exception ex, CatRepatriationApplyAddRepatriationRecordEvent @event)
    {
        throw new HandlerException($"{nameof(CatRepatriationApplyAddRepatriationRecordEventHandler)}", ex);
    }
}