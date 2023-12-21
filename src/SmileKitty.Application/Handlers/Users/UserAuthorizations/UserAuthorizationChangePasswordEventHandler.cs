using Microsoft.EntityFrameworkCore;
using SmileKitty.Application.Exceptions;
using SmileKitty.Domain.Shared.Events.Users.UserAuthorizations;
using SmileKitty.Domain.Users;
using SmileKitty.EntityFrameworkCore.UnitOfWorks;
using SmileKitty.EventBus.Handler;

namespace SmileKitty.Application.Handlers.Users.UserAuthorizations;

public class UserAuthorizationChangePasswordEventHandler(IUnitOfWork<UserAuthorization> unitOfWork) : IEventHandler<UserAuthorizationChangePasswordEvent>
{
    private readonly IUnitOfWork<UserAuthorization> _unitOfWork = unitOfWork;
    public async Task HandleAsync(UserAuthorizationChangePasswordEvent @event)
    {
        var ua = await _unitOfWork.Queryable.Where(x => x.Id == @event.UserAuthorizationId).FirstOrDefaultAsync();
        if (ua is null)
        {
            throw new ArgumentNullException(nameof(@event.UserAuthorizationId), $"用户不存在");
        }

        ua.Password = @event.Password;
        await _unitOfWork.UpdateAsync(ua);
    }

    public void ExceptionHandle(Exception ex, UserAuthorizationChangePasswordEvent @event)
    {
        throw new HandlerException($"{nameof(UserAuthorizationChangePasswordEventHandler)}", ex);
    }
}