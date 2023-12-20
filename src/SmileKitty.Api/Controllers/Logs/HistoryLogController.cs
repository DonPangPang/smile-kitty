using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmileKitty.Application.Contracts.Logs.HistoryLogs;
using SmileKitty.AutoMapper;
using SmileKitty.Domain.Logs;
using SmileKitty.EntityFrameworkCore.UnitOfWorks;

namespace SmileKitty.Api.Controllers.Logs;

public class HistoryLogController(IUnitOfWork<HistoryLog> unitOfWork)
    : ApiControllerBase
{
    private readonly IUnitOfWork<HistoryLog> _unitOfWork = unitOfWork;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _unitOfWork.Queryable.Map<HistoryLog, HistoryLogDto>().ToListAsync();
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var result = await _unitOfWork.Queryable.Map<HistoryLog, HistoryLogDto>().FirstOrDefaultAsync(x => x.Id == id);
        return Ok(result);
    }
}