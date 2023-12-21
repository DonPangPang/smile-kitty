using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmileKitty.Application.Contracts.Donations.DonationOutRecords;
using SmileKitty.AutoMapper;
using SmileKitty.Domain.Donations;
using SmileKitty.EntityFrameworkCore.UnitOfWorks;

namespace SmileKitty.Api.Controllers.Donations;

public class DonationOutRecordController(IUnitOfWork<DonationOutRecord> unitOfWork)
    : RApiControllerBase<DonationOutRecord, DonationOutRecordQueryParameter, DonationOutRecordDto>(unitOfWork)
{
    private readonly IUnitOfWork<DonationOutRecord> _unitOfWork = unitOfWork;

    public override async Task<IActionResult> Get(DonationOutRecordQueryParameter parameter)
    {
        var result = await _unitOfWork.Queryable.Map<DonationOutRecord, DonationOutRecordDto>().ToListAsync();

        return Ok(result);
    }
}