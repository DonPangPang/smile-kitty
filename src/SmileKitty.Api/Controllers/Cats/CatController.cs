using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmileKitty.Application.Contracts.Cats.Cats;
using SmileKitty.AutoMapper;
using SmileKitty.Domain.Cats;
using SmileKitty.EntityFrameworkCore.UnitOfWorks;

namespace SmileKitty.Api.Controllers.Cats;

public class CatController(IUnitOfWork<Cat> unitOfWork) : CrudApiControllerBase<Cat, CatQueryParameter, CatDto, CatAddDto, CatUpdateDto>(unitOfWork)
{
    private readonly IUnitOfWork<Cat> _unitOfWork = unitOfWork;
    public override async Task<IActionResult> Get(CatQueryParameter parameter)
    {
        var res = await _unitOfWork.Queryable.Map<Cat, CatDto>().ToListAsync();

        return Ok(res);
    }

    public override async Task<IActionResult> Add(CatAddDto dto)
    {
        var cat = dto.MapTo<Cat>();
        cat.CreateLife();
        cat.CreateDonation();
        await _unitOfWork.InsertAsync(cat);
        await _unitOfWork.CommitAsync();

        return Ok();
    }
}