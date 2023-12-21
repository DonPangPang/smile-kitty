﻿using SmileKitty.Application.Contracts.Donations.Donations;
using SmileKitty.Application.Contracts.Users.Users;
using SmileKitty.Infrastructure.Dto;

namespace SmileKitty.Application.Contracts.Donations.DonationInRecords;

public class DonationInRecordDto : DtoBase
{
    public Guid? UserId { get; set; }
    public UserDto? User { get; set; }
    public Guid DonationId { get; set; }
    public DonationDto? Donation { get; set; }
    public string? Description { get; set; }

    public decimal Amount { get; set; }

    public DateTime CreateTime { get; set; }

    public bool IsAnonymous { get; set; }
}