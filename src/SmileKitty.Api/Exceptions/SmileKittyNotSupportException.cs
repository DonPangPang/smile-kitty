using SmileKitty.Infrastructure.Exceptions;

namespace SmileKitty.Api.Exceptions;

public class SmileKittyNotSupportException(string? message = null, Exception? ex = null)
    : SmileKittyException(message ?? "该方法并不支持", ex);