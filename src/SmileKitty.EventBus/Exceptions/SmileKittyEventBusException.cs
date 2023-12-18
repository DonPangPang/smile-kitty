namespace SmileKitty.EventBus.Exceptions;

public class SmileKittyEventBusException(string? message = null, Exception? ex = null)
    : Exception(message, ex);