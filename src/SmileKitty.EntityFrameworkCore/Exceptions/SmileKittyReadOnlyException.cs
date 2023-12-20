using SmileKitty.Infrastructure.Exceptions;

namespace SmileKitty.EntityFrameworkCore.Exceptions;

public class SmileKittyReadOnlyException(string? message = null, Exception? ex = null) : SmileKittyException(message ?? "只读", ex)
{

}