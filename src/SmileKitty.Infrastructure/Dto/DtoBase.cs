namespace SmileKitty.Infrastructure.Dto;

public abstract class DtoBase : IDto
{
    public Guid Id { get; set; }
}