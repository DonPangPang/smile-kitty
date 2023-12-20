using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmileKitty.Application.Contracts.Logs.LoginLogs;
using SmileKitty.AutoMapper;
using SmileKitty.Domain.Logs;
using SmileKitty.EntityFrameworkCore.UnitOfWorks;

namespace SmileKitty.Api.Controllers.Logs;

public class LoginLogController(IUnitOfWork<LoginLog> unitOfWork)
    : ApiControllerBase
{
    private readonly IUnitOfWork<LoginLog> _unitOfWork = unitOfWork;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _unitOfWork.Queryable.Map<LoginLog, LoginLogDto>().ToListAsync();
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var result = await _unitOfWork.Queryable.Map<LoginLog, LoginLogDto>().FirstOrDefaultAsync(x => x.Id == id);
        return Ok(result);
    }
}