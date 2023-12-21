using System.Diagnostics;

namespace SmileKitty.Infrastructure.Common;

public static class CommonExtensions
{

}

public static class OutputHelper
{
    private const string Title = "smilekitty-log: ";

    public static void Write(this string? message)
    {
        Console.WriteLine($"{Title}{message}");
#if DEBUG
        Trace.WriteLine($"{Title}{message}");
#endif
    }
}