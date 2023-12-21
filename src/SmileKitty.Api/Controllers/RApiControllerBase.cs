using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmileKitty.AutoMapper;
using SmileKitty.EntityFrameworkCore.UnitOfWorks;
using SmileKitty.Infrastructure.Dto;
using SmileKitty.Infrastructure.Entity;
using SmileKitty.Infrastructure.QueryParameter;

namespace SmileKitty.Api.Controllers;

public abstract class RApiControllerBase<TEntity, TQueryParameter, TDto>(IUnitOfWork<TEntity> unitOfWork)
    : ApiControllerBase
    where TEntity : class, IEntity
    where TQueryParameter : IQueryParameter
    where TDto : DtoBase
{
    [HttpGet]
    public abstract Task<IActionResult> Get([FromQuery] TQueryParameter parameter);

    [HttpGet]
    public async Task<IActionResult> Get(Guid id)
    {
        var res = await unitOfWork.Queryable.Map<TEntity, TDto>().FirstOrDefaultAsync(x => x.Id == id);
        if (res is null) return NotFound();

        return Ok(res);
    }
}