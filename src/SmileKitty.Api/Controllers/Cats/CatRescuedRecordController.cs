using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmileKitty.Application.Contracts.Cats.CatRescuedRecords;
using SmileKitty.AutoMapper;
using SmileKitty.Domain.Cats;
using SmileKitty.EntityFrameworkCore.UnitOfWorks;

namespace SmileKitty.Api.Controllers.Cats;

public class CatRescuedRecordController(IUnitOfWork<CatRescuedRecord> unitOfWork)
    : ApiControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get(CatRescuedRecordQueryParameter parameter)
    {
        var res = await unitOfWork.Queryable.Map<CatRescuedRecord, CatRescuedRecordDto>().ToListAsync();

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