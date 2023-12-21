using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmileKitty.Application.Contracts.Cats.CatRepatriationApplys;
using SmileKitty.AutoMapper;
using SmileKitty.Domain.Cats;
using SmileKitty.EntityFrameworkCore.UnitOfWorks;

namespace SmileKitty.Api.Controllers.Cats;

public class CatRepatriationApplyController(IUnitOfWork<CatRepatriationApply> unitOfWork)
    : ApiControllerBase
{
    private readonly IUnitOfWork<CatRepatriationApply> _unitOfWork = unitOfWork;

    [HttpGet]
    public async Task<IActionResult> Get(CatRepatriationApplyQueryParameter parameter)
    {
        var res = await _unitOfWork.Queryable.Map<CatRepatriationApply, CatRepatriationApplyDto>().ToListAsync();

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
    public async Task<IActionResult> Apply(CatRepatriationApplyAddDto dto)
    {
        var entity = dto.MapTo<CatRepatriationApply>();
        await _unitOfWork.InsertAsync(entity);
        await _unitOfWork.CommitAsync();

        return Ok();
    }

    [HttpPost("Approval")]
    public async Task<IActionResult> Approval(CatRepatriationApplyApprovalDto dto)
    {
        var entity = await _unitOfWork.Queryable.FirstOrDefaultAsync(x => x.Id == dto.Id);
        if (entity is null) return NotFound();

        // TODO: CurrentUser
        //entity.HandleFlow(dto.Result, null);

        await _unitOfWork.UpdateAsync(entity);
        await _unitOfWork.CommitAsync();

        return Ok();
    }
}