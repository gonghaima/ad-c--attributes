#define LOG_INFO
using System.Reflection;
using LoggingComponent;

// [assembly:AssemblyVersion("2.0.1")]
[assembly: AssemblyDescription("This is a sample description")]
namespace AttributesExamples;

class Program
{
    static void Main(string[] args)
    {
        Logging.LogToScreen("This code is testing logging functionality");
        Console.ReadKey();
    }

    private static void OutputGlobalAttributeInformation()
    {
        Assembly assembly = typeof(Program).Assembly;

        AssemblyName assemblyName = assembly.GetName();

        Version version = assemblyName.Version;

        object[] attributes = assembly.GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
        var assemblyDescriptionAttribute = attributes[0] as AssemblyDescriptionAttribute;



        Console.WriteLine($"Assembly Name: {assemblyName.Name}");
        Console.WriteLine($"Version: {version}");
        if (assemblyDescriptionAttribute != null)
        {
            Console.WriteLine($"Description: {assemblyDescriptionAttribute.Description}");
        }
    }
}

