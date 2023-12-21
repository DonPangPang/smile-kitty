using Microsoft.EntityFrameworkCore;
using SmileKitty.Application.Exceptions;
using SmileKitty.Domain.Donations;
using SmileKitty.Domain.Shared.Events.Donations.DonationOutRecords;
using SmileKitty.EntityFrameworkCore.UnitOfWorks;
using SmileKitty.EventBus.Handler;

namespace SmileKitty.Application.Handlers.Donations.DonationOutRecords;

public class DonationOutRecordAddEventHandler(IUnitOfWork<DonationOutRecord> donationOutRecordUnitOfWork
    , IUnitOfWork<Donation> donationUnitOfWork) : IEventHandler<DonationOutRecordAddEvent>
{
    private readonly IUnitOfWork<DonationOutRecord> _donationOutRecordUnitOfWork = donationOutRecordUnitOfWork;
    private readonly IUnitOfWork<Donation> _donationUnitOfWork = donationUnitOfWork;
    public async Task HandleAsync(DonationOutRecordAddEvent @event)
    {
        if (@event.Amount <= 0)
        {
            throw new ArgumentNullException(nameof(@event.Amount), $"支出金额必须大于0");
        }

        var donation = await _donationUnitOfWork.Queryable.Where(x => x.Id == @event.CatId).FirstOrDefaultAsync();

        if (donation is null)
        {
            throw new ArgumentNullException(nameof(@event.CatId), $"款项不存在");
        }

        if (@event.Amount > donation.Amount)
        {
            throw new ArgumentNullException(nameof(@event.Amount), $"款项余额不足");
        }

        await _donationOutRecordUnitOfWork.InsertAsync(new DonationOutRecord
        {
            DonationId = donation.Id,
            Amount = @event.Amount,
            CreateTime = DateTime.Now,
            Description = @event.Description,
            UserId = @event.UserId
        });

        donation.Amount -= @event.Amount;
        await _donationUnitOfWork.UpdateAsync(donation);
    }

    public void ExceptionHandle(Exception ex, DonationOutRecordAddEvent @event)
    {
        throw new HandlerException($"{nameof(DonationOutRecordAddEventHandler)}", ex);
    }
}