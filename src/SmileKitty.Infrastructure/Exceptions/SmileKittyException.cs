namespace SmileKitty.Infrastructure.Exceptions;

public class SmileKittyException(string? message = null, Exception? ex = null) : Exception(message, ex);