using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmileKitty.Application.Contracts.Logs.PasswordChangeLogs;
using SmileKitty.AutoMapper;
using SmileKitty.Domain.Logs;
using SmileKitty.EntityFrameworkCore.UnitOfWorks;

namespace SmileKitty.Api.Controllers.Logs;

public class PasswordChangeLogController(IUnitOfWork<PasswordChangeLog> unitOfWork)
    : ApiControllerBase
{
    private readonly IUnitOfWork<PasswordChangeLog> _unitOfWork = unitOfWork;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _unitOfWork.Queryable.Map<PasswordChangeLog, PasswordChangeLogDto>().ToListAsync();
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var result = await _unitOfWork.Queryable.Map<PasswordChangeLog, PasswordChangeLogDto>().FirstOrDefaultAsync(x => x.Id == id);
        return Ok(result);
    }
}