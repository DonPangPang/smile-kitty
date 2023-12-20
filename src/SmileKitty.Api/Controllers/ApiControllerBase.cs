using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmileKitty.AutoMapper;
using SmileKitty.EntityFrameworkCore.UnitOfWorks;
using SmileKitty.Infrastructure.Dto;
using SmileKitty.Infrastructure.Entity;
using SmileKitty.Infrastructure.QueryParameter;

namespace SmileKitty.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class ApiControllerBase : ControllerBase
{

}

public abstract class CrudApiControllerBase<TEntity, TQueryParameter, TDto, TAddDto, TUpdateDto>
    (IUnitOfWork<TEntity> unitOfWork) : ApiControllerBase
    where TEntity : class, IEntity
    where TQueryParameter : IQueryParameter
    where TDto : DtoBase
    where TAddDto : IDto
    where TUpdateDto : DtoBase
{
    [HttpGet]
    public abstract Task<IActionResult> Get([FromQuery] TQueryParameter parameter);

    [HttpGet("{id:guid}")]
    public virtual async Task<IActionResult> Get(Guid id)
    {
        var res = await unitOfWork.Queryable.FirstOrDefaultAsync(x => x.Id == id);
        if (res is null) return NotFound();

        return Ok(res);
    }

    [HttpPost]
    public virtual async Task<IActionResult> Add([FromBody] TAddDto dto)
    {
        var entity = dto.MapTo<TEntity>();
        await unitOfWork.InsertAsync(entity);
        await unitOfWork.CommitAsync();

        return Ok();
    }

    [HttpPut]
    public virtual async Task<IActionResult> Update([FromBody] TUpdateDto dto)
    {
        var entity = await unitOfWork.Queryable.FirstOrDefaultAsync(x => x.Id == dto.Id);
        if (entity is null) return NotFound();

        entity.Map(dto);
        await unitOfWork.UpdateAsync(entity);

        await unitOfWork.CommitAsync();

        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public virtual async Task<IActionResult> Delete(Guid id)
    {
        var entity = await unitOfWork.Queryable.FirstOrDefaultAsync(x => x.Id == id);
        if (entity is null) return Ok();

        await unitOfWork.DeleteAsync(entity);

        await unitOfWork.CommitAsync();

        return Ok();
    }
}

public abstract class CrudeApiControllerBase<TEntity, TQueryParameter, TDto, TAddDto, TUpdateDto>(
    IUnitOfWork<TEntity> unitOfWork)
    : CrudApiControllerBase<TEntity, TQueryParameter, TDto, TAddDto, TUpdateDto>(unitOfWork)
    where TEntity : class, IEntity, IEnable
    where TQueryParameter : IQueryParameter
    where TDto : DtoBase
    where TAddDto : IDto
    where TUpdateDto : DtoBase
{
    private readonly IUnitOfWork<TEntity> _unitOfWork = unitOfWork;

    [HttpGet("{id:guid}/{enable:bool}")]
    public virtual async Task<IActionResult> Enable(Guid id, bool enable)
    {
        var entity = await _unitOfWork.Queryable.FirstOrDefaultAsync(x => x.Id == id);

        if (entity is null) return NotFound();

        entity.IsEnable = enable;

        await _unitOfWork.UpdateAsync(entity);
        await _unitOfWork.CommitAsync();

        return Ok();
    }
}