namespace SmileKitty.Infrastructure.Dto;

public interface IDto
{
    public Guid Id { get; set; }
}

public abstract class DtoBase : IDto
{
    public Guid Id { get; set; }
}