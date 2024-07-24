using System.Diagnostics;
namespace LoggingComponent;

public class Logging
{
    [Conditional("LOG_INFO")]
    public static void LogToScreen(string message)
    {
        Console.WriteLine(message);
    }
}

