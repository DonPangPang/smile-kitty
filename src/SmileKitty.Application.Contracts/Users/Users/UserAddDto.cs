using SmileKitty.Application.Contracts.Resources.Dtos;
using SmileKitty.Domain.Shared.Enums;
using SmileKitty.Infrastructure.Dto;

namespace SmileKitty.Application.Contracts.Users.Users;

public class UserAddDto : DtoBase
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public Gender Gender { get; set; }
    public string? Phone { get; set; }
    public ImageResourceDto? Avatar { get; set; }
    public string? Description { get; set; }
}