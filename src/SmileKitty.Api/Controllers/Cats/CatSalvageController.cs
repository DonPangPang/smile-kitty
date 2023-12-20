using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmileKitty.Application.Contracts.Cats.CatSalvages;
using SmileKitty.AutoMapper;
using SmileKitty.Domain.Cats;
using SmileKitty.EntityFrameworkCore.UnitOfWorks;

namespace SmileKitty.Api.Controllers.Cats;

public class CatSalvageController(IUnitOfWork<CatSalvage> unitOfWork)
    : CrudApiControllerBase<CatSalvage, CatSalvageQueryParameter, CatSalvageDto, CatSalvageAddDto, CatSalvageUpdateDto>(
        unitOfWork)
{
    private readonly IUnitOfWork<CatSalvage> _unitOfWork = unitOfWork;

    public override async Task<IActionResult> Get(CatSalvageQueryParameter parameter)
    {
        var res = await _unitOfWork.Queryable.Map<CatSalvage, CatSalvageDto>().ToListAsync();

        return Ok(res);
    }

    [Obsolete]
    public override Task<IActionResult> Update(CatSalvageUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    [Obsolete]
    public override Task<IActionResult> Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}