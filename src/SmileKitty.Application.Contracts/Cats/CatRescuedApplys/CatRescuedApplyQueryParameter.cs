﻿using SmileKitty.Domain.Shared.Enums;
using SmileKitty.Infrastructure.QueryParameter;

namespace SmileKitty.Application.Contracts.Cats.CatRescuedApplys;

public class CatRescuedApplyQueryParameter : IQueryParameter, IPaging, IOrdering, ITimeRage
{
    public Guid? CatId { get; set; }
    public Guid? UserId { get; set; }
    public string? Address { get; set; }
    public FlowResult? Result { get; set; }

    public string? OrderBy { get; set; }
    public int? PageIndex { get; set; }
    public int? PageSize { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
}