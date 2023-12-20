﻿using SmileKitty.Domain.Shared.Enums;
using SmileKitty.Infrastructure.QueryParameter;

namespace SmileKitty.Application.Contracts.Users.Users;

public class UserQueryParameter : IQueryParameter, IPaging, IOrdering
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public Gender Gender { get; set; }
    public string? Phone { get; set; }
    public string? Description { get; set; }
    public DateTime CreateTime { get; private set; }

    public Guid UserAuthorizationId { get; set; }

    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public string? OrderBy { get; set; }
}