using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmileKitty.Application.Contracts.Donations.Donations;
using SmileKitty.AutoMapper;
using SmileKitty.Domain.Donations;
using SmileKitty.EntityFrameworkCore.UnitOfWorks;

namespace SmileKitty.Api.Controllers.Donations;

public class DonationController(IUnitOfWork<Donation> unitOfWork)
    : RApiControllerBase<Donation, DonationQueryParameter, DonationDto>(unitOfWork)
{
    private readonly IUnitOfWork<Donation> _unitOfWork = unitOfWork;
    public override async Task<IActionResult> Get(DonationQueryParameter parameter)
    {
        var result = await _unitOfWork.Queryable.Map<Donation, DonationDto>().ToListAsync();

        return Ok(result);
    }
}