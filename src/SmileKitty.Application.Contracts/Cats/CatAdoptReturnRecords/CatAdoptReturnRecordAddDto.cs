﻿using SmileKitty.Infrastructure.Dto;

namespace SmileKitty.Application.Contracts.Cats.CatAdoptReturnRecords;

public class CatAdoptReturnRecordAddDto : IDto
{
    public Guid CatId { get; set; }
    public Guid UserId { get; set; }
    public string? Description { get; set; }

    public Guid CatAdoptionRecordId { get; set; }
}