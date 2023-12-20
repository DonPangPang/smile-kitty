using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmileKitty.Application.Contracts.Cats.CatAdoptReturnRecords;
using SmileKitty.AutoMapper;
using SmileKitty.Domain.Cats;
using SmileKitty.EntityFrameworkCore.UnitOfWorks;

namespace SmileKitty.Api.Controllers.Cats;

public class CatAdoptReturnRecordController(IUnitOfWork<CatAdoptReturnRecord> unitOfWork)
    : CrudApiControllerBase<CatAdoptReturnRecord, CatAdoptReturnRecordQueryParameter, CatAdoptReturnRecordDto, CatAdoptReturnRecordAddDto, CatAdoptReturnRecordUpdateDto>(unitOfWork)
{
    private readonly IUnitOfWork<CatAdoptReturnRecord> _unitOfWork = unitOfWork;

    [HttpGet]
    public override async Task<IActionResult> Get(CatAdoptReturnRecordQueryParameter parameter)
    {
        var res = await _unitOfWork.Queryable.Map<CatAdoptReturnRecord, CatAdoptReturnRecordDto>().ToListAsync();

        return Ok(res);
    }
}