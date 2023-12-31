﻿using SmileKitty.EventBus.Event;

namespace SmileKitty.Domain.Shared.Events.Users.UserAuthorizations;

public class UserAuthorizationLoginEvent : IEvent
{
    public Guid UserAuthorizationId { get; set; }
    public DateTime LoginTime { get; set; }
}