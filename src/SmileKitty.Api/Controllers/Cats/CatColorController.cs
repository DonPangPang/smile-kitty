using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmileKitty.Application.Contracts.Cats.CatColors;
using SmileKitty.AutoMapper;
using SmileKitty.Domain.Cats;
using SmileKitty.EntityFrameworkCore.UnitOfWorks;

namespace SmileKitty.Api.Controllers.Cats;

public class CatColorController(IUnitOfWork<CatColor> unitOfWork)
    : CrudApiControllerBase<CatColor, CatColorQueryParameter, CatColorDto, CatColorAddDto, CatColorUpdateDto>(
        unitOfWork)
{
    private readonly IUnitOfWork<CatColor> _unitOfWork = unitOfWork;

    [HttpGet]
    public override async Task<IActionResult> Get(CatColorQueryParameter parameter)
    {
        var res = await _unitOfWork.Queryable.Map<CatColor, CatColorDto>().ToListAsync();

        return Ok(res);
    }
}