using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmileKitty.Application.Contracts.Cats.CatRepatriationRecords;
using SmileKitty.AutoMapper;
using SmileKitty.Domain.Cats;
using SmileKitty.EntityFrameworkCore.UnitOfWorks;

namespace SmileKitty.Api.Controllers.Cats;

public class CatRepatriationRecordController(IUnitOfWork<CatRepatriationRecord> unitOfWork)
    : ApiControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get(CatRepatriationRecordQueryParameter parameter)
    {
        var res = await unitOfWork.Queryable.Map<CatRepatriationRecord, CatRepatriationRecordDto>().ToListAsync();

        return Ok(res);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var res = await unitOfWork.Queryable.FirstOrDefaultAsync(x => x.Id == id);
        if (res is null) return NotFound();

        return Ok(res);
    }
}