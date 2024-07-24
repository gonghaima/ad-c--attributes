using System.Diagnostics;
namespace LoggingComponent;

public class Class1
{
    [Conditional("LOG_INFO")]
    public static void Log(string message)
    {
        Console.WriteLine(message);
    }
}

