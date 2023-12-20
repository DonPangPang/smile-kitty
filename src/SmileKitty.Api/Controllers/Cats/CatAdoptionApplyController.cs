using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmileKitty.Application.Contracts.Cats.CatAdoptionApplys;
using SmileKitty.AutoMapper;
using SmileKitty.Domain.Cats;
using SmileKitty.EntityFrameworkCore.UnitOfWorks;

namespace SmileKitty.Api.Controllers.Cats;

public class CatAdoptionApplyController(IUnitOfWork<CatAdoptionApply> unitOfWork)
    : ApiControllerBase
{
    private readonly IUnitOfWork<CatAdoptionApply> _unitOfWork = unitOfWork;

    [HttpGet]
    public async Task<IActionResult> Get(CatAdoptionApplyQueryParameter parameter)
    {
        var res = await _unitOfWork.Queryable.Map<CatAdoptionApply, CatAdoptionApplyDto>().ToListAsync();

        return Ok(res);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var res = await _unitOfWork.Queryable.FirstOrDefaultAsync(x => x.Id == id);
        if (res is null) return NotFound();

        return Ok(res);
    }

    [HttpPost("Apply")]
    public async Task<IActionResult> Apply(CatAdoptionApplyAddDto dto)
    {
        var entity = dto.MapTo<CatAdoptionApply>();
        await _unitOfWork.InsertAsync(entity);
        await _unitOfWork.CommitAsync();

        return Ok();
    }

    [HttpPost("Approval")]
    public async Task<IActionResult> Approval(CatAdoptionApplyApprovalDto dto)
    {
        var entity = await _unitOfWork.Queryable.FirstOrDefaultAsync(x => x.Id == dto.Id);
        if (entity is null) return NotFound();

        // TODO: CurrentUser
        entity.HandleFlow(dto.Result, null);

        await _unitOfWork.UpdateAsync(entity);
        await _unitOfWork.CommitAsync();

        return Ok();
    }
}