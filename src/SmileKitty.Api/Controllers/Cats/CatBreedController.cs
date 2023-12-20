using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmileKitty.Application.Contracts.Cats.CatBreeds;
using SmileKitty.AutoMapper;
using SmileKitty.Domain.Cats;
using SmileKitty.EntityFrameworkCore.UnitOfWorks;

namespace SmileKitty.Api.Controllers.Cats;

public class CatBreedController(IUnitOfWork<CatBreed> unitOfWork)
    : CrudApiControllerBase<CatBreed, CatBreedQueryParameter, CatBreedDto, CatBreedAddDto, CatBreedUpdateDto>(unitOfWork)
{
    private readonly IUnitOfWork<CatBreed> _unitOfWork = unitOfWork;

    [HttpGet]
    public override async Task<IActionResult> Get(CatBreedQueryParameter parameter)
    {
        var res = await _unitOfWork.Queryable.Map<CatBreed, CatBreedDto>().ToListAsync();

        return Ok(res);
    }

}