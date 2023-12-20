using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmileKitty.Application.Contracts.Cats.CatLifes;
using SmileKitty.AutoMapper;
using SmileKitty.Domain.Cats;
using SmileKitty.EntityFrameworkCore.UnitOfWorks;

namespace SmileKitty.Api.Controllers.Cats;

public class CatLifeController(IUnitOfWork<CatLife> unitOfWork)
    : ApiControllerBase
{
    private readonly IUnitOfWork<CatLife> _unitOfWork = unitOfWork;

    [HttpGet]
    public async Task<IActionResult> Get(CatLiftQueryParameter parameter)
    {
        var res = await _unitOfWork.Queryable.Map<CatLife, CatLifeDto>().ToListAsync();

        return Ok(res);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var res = await _unitOfWork.Queryable.FirstOrDefaultAsync(x => x.Id == id);
        if (res is null) return NotFound();

        return Ok(res);
    }
}