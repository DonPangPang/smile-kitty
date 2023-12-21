using Microsoft.EntityFrameworkCore;
using SmileKitty.Application.Exceptions;
using SmileKitty.Domain.Donations;
using SmileKitty.Domain.Shared.Events.Donations.DonationInRecords;
using SmileKitty.EntityFrameworkCore.UnitOfWorks;
using SmileKitty.EventBus.Handler;

namespace SmileKitty.Application.Handlers.Donations.DonationInRecords;

public class DonationInRecordAddEventHandler(IUnitOfWork<DonationInRecord> donationInRecordUnitOfWork,
    IUnitOfWork<Donation> donationUnitOfWork) : IEventHandler<DonationInRecordAddEvent>
{
    private readonly IUnitOfWork<DonationInRecord> _donationInRecordUnitOfWork = donationInRecordUnitOfWork;
    private readonly IUnitOfWork<Donation> _donationUnitOfWork = donationUnitOfWork;

    public async Task HandleAsync(DonationInRecordAddEvent @event)
    {
        if (@event.Amount <= 0)
        {
            throw new ArgumentNullException(nameof(@event.Amount), $"捐赠金额必须大于0");
        }
        var donation = await _donationUnitOfWork.Queryable.Where(x => x.Id == @event.DonationId).FirstOrDefaultAsync();
        if (donation is null)
        {
            throw new ArgumentNullException(nameof(@event.DonationId), $"捐赠不存在");
        }

        await _donationInRecordUnitOfWork.InsertAsync(new DonationInRecord
        {
            DonationId = @event.DonationId,
            Amount = @event.Amount,
            CreateTime = DateTime.Now,
            Description = @event.Description,
            IsAnonymous = @event.IsAnonymous,
            UserId = @event.UserId
        });

        donation.Amount += @event.Amount;
        await _donationUnitOfWork.UpdateAsync(donation);
    }

    public void ExceptionHandle(Exception ex, DonationInRecordAddEvent @event)
    {
        throw new HandlerException($"{nameof(DonationInRecordAddEventHandler)}", ex);
    }
}