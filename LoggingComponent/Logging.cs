using System.Diagnostics;
namespace LoggingComponent;

public class Logging
{
    // [Conditional("LOG_INFO")]
    [Obsolete("Use LogToFile instead", false)]
    public static void LogToScreen(string message)
    {
        Console.WriteLine(message);
    }

    public static void LogToFile(string message)
    {
        Console.WriteLine(message);
    }
}

