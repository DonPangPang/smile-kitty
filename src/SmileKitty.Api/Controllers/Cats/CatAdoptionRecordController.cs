using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmileKitty.Application.Contracts.Cats.CatAdoptionRecords;
using SmileKitty.AutoMapper;
using SmileKitty.Domain.Cats;
using SmileKitty.EntityFrameworkCore.UnitOfWorks;

namespace SmileKitty.Api.Controllers.Cats;

public class CatAdoptionRecordController(IUnitOfWork<CatAdoptionRecord> unitOfWork)
    : ApiControllerBase
{
    private readonly IUnitOfWork<CatAdoptionRecord> _unitOfWork = unitOfWork;

    [HttpGet]
    public async Task<IActionResult> Get(CatAdoptionRecordQueryParameter parameter)
    {
        var res = await _unitOfWork.Queryable.Map<CatAdoptionRecord, CatAdoptionRecordDto>().ToListAsync();

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