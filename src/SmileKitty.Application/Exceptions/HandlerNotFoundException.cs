using SmileKitty.Infrastructure.Exceptions;

namespace SmileKitty.Application.Exceptions;

public class HandlerNotFoundException(string? message = null, Exception? ex = null) : SmileKittyException(message, ex);