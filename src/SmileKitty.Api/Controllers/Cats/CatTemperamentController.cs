using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmileKitty.Application.Contracts.Cats.CatTemperaments;
using SmileKitty.AutoMapper;
using SmileKitty.Domain.Cats;
using SmileKitty.EntityFrameworkCore.UnitOfWorks;

namespace SmileKitty.Api.Controllers.Cats;

public class CatTemperamentController(IUnitOfWork<CatTemperament> unitOfWork)
    : CrudApiControllerBase<CatTemperament, CatTemperamentQueryParameter, CatTemperamentDto, CatTemperamentAddDto,
        CatTemperamentUpdateDto>(
        unitOfWork)
{
    private readonly IUnitOfWork<CatTemperament> _unitOfWork = unitOfWork;

    public override async Task<IActionResult> Get(CatTemperamentQueryParameter parameter)
    {
        var res = await _unitOfWork.Queryable.Map<CatTemperament, CatTemperamentDto>().ToListAsync();

        return Ok(res);
    }
}