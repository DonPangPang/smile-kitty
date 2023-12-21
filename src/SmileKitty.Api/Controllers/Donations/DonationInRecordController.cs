using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmileKitty.Application.Contracts.Donations.DonationInRecords;
using SmileKitty.AutoMapper;
using SmileKitty.Domain.Donations;
using SmileKitty.EntityFrameworkCore.UnitOfWorks;

namespace SmileKitty.Api.Controllers.Donations;

public class DonationInRecordController(IUnitOfWork<DonationInRecord> unitOfWork)
    : RApiControllerBase<DonationInRecord, DonationInRecordQueryParameter, DonationInRecordDto>(unitOfWork)
{
    private readonly IUnitOfWork<DonationInRecord> _unitOfWork = unitOfWork;

    public override async Task<IActionResult> Get(DonationInRecordQueryParameter parameter)
    {
        var result = await _unitOfWork.Queryable.Map<DonationInRecord, DonationInRecordDto>().ToListAsync();

        return Ok(result);
    }
}