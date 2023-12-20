using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmileKitty.Application.Contracts.Cats.CatPosts;
using SmileKitty.AutoMapper;
using SmileKitty.Domain.Cats;
using SmileKitty.EntityFrameworkCore.UnitOfWorks;

namespace SmileKitty.Api.Controllers.Cats;

public class CatPostController(IUnitOfWork<CatPost> unitOfWork)
    : CrudApiControllerBase<CatPost, CatPostQueryParameter, CatPostDto, CatPostAddDto, CatPostUpdateDto>(unitOfWork)
{
    private readonly IUnitOfWork<CatPost> _unitOfWork = unitOfWork;

    [HttpGet]
    public override async Task<IActionResult> Get(CatPostQueryParameter parameter)
    {
        var res = await _unitOfWork.Queryable.Map<CatPost, CatPostDto>().ToListAsync();

        return Ok(res);
    }
}