using SmileKitty.AutoMapper;
using SmileKitty.Domain.Shared.Events.Users;
using SmileKitty.Domain.Users;
using SmileKitty.EntityFrameworkCore;
using SmileKitty.EventBus.Handler;

namespace SmileKitty.Application.Handlers.Users;

public class UserAddEventHandler(SmileKittyDbContext dbContext) : IEventHandler<UserAddEvent>
{
    public async Task HandleAsync(UserAddEvent @event)
    {
        var user = @event.MapTo<User>();
        await dbContext.AddAsync(user);
    }

    public void ExceptionHandle(Exception ex, UserAddEvent @event)
    {
        throw new NotImplementedException();
    }
}