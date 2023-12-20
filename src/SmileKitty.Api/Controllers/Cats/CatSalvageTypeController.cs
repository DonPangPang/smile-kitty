using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmileKitty.Application.Contracts.Cats.CatSalvageTypes;
using SmileKitty.AutoMapper;
using SmileKitty.Domain.Cats;
using SmileKitty.EntityFrameworkCore.UnitOfWorks;

namespace SmileKitty.Api.Controllers.Cats;

public class CatSalvageTypeController(IUnitOfWork<CatSalvageType> unitOfWork)
    : CrudApiControllerBase<CatSalvageType, CatSalvageTypeQueryParameter, CatSalvageTypeDto, CatSalvageTypeAddDto,
        CatSalvageTypeUpdateDto>(
        unitOfWork)
{
    private readonly IUnitOfWork<CatSalvageType> _unitOfWork = unitOfWork;

    public override async Task<IActionResult> Get(CatSalvageTypeQueryParameter parameter)
    {
        var res = await _unitOfWork.Queryable.Map<CatSalvageType, CatSalvageTypeDto>().ToListAsync();

        return Ok(res);
    }
}