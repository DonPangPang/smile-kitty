using SmileKitty.Infrastructure.Exceptions;

namespace SmileKitty.Application.Exceptions;


public class HandlerException(string? message = null, Exception? ex = null) : SmileKittyException(message, ex);
public class HandlerNotFoundException(string? message = null, Exception? ex = null) : SmileKittyException(message, ex);