using IP2Region.Net.Abstractions;
using Microsoft.AspNetCore.Http;
using SmileKitty.Application.Exceptions;
using SmileKitty.Domain.Logs;
using SmileKitty.Domain.Shared.Events.Users.UserAuthorizations;
using SmileKitty.EntityFrameworkCore.UnitOfWorks;
using SmileKitty.EventBus.Handler;

namespace SmileKitty.Application.Handlers.Users.UserAuthorizations;

public class UserAuthorizationLoginEventHandler(IUnitOfWork<LoginLog> unitOfWork,
    IHttpContextAccessor httpContextAccessor, ISearcher searcher)
    : IEventHandler<UserAuthorizationLoginEvent>
{
    private readonly IUnitOfWork<LoginLog> _unitOfWork = unitOfWork;

    public async Task HandleAsync(UserAuthorizationLoginEvent @event)
    {
        var ip = httpContextAccessor.HttpContext?.Connection.RemoteIpAddress?.ToString();
        await _unitOfWork.UpdateAsync(new LoginLog
        {
            UserAuthorizationId = @event.UserAuthorizationId,
            Ip = ip ?? "Unknown IP Address",
            IpAddress = searcher.Search(ip ?? "127.0.0.1") ?? "Unknown IP Location Address",
            UserAgent = httpContextAccessor.HttpContext?.Request.Headers["User-Agent"].ToString() ?? "Unknown User Agent",
            CreateTime = @event.LoginTime,
        });
    }

    public void ExceptionHandle(Exception ex, UserAuthorizationLoginEvent @event)
    {
        throw new HandlerException($"{nameof(UserAuthorizationLoginEventHandler)}", ex);
    }
}