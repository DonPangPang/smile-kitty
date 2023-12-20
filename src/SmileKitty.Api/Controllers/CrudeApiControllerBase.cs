using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmileKitty.EntityFrameworkCore.UnitOfWorks;
using SmileKitty.Infrastructure.Dto;
using SmileKitty.Infrastructure.Entity;
using SmileKitty.Infrastructure.QueryParameter;

namespace SmileKitty.Api.Controllers;

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