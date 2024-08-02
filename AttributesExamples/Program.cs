#define LOG_INFO
using System.Reflection;
using LoggingComponent;
using ValidationComponent;
using AttributesExamples.Models;

// [assembly:AssemblyVersion("2.0.1")]
[assembly: AssemblyDescription("This is a sample description")]
namespace AttributesExamples;

class Program
{
    static void Main(string[] args)
    {
        Employee emp = new Employee();
        Department dept = new Department();

        string empId = null;
        string firstName = null;
        string postCode = null;
        string deptShortName = null;


        Type employeeType = typeof(Employee);
        Type departmentType = typeof(Department);

        if (GetInput(employeeType, "Please enter the employee's id", "Id", out empId))
        {
            emp.Id = Int32.Parse(empId);
        }
        if (GetInput(employeeType, "Please enter the employee's first name", "FirstName", out firstName))
        {
            emp.FirstName = firstName;
        }
        if (GetInput(employeeType, "Please enter the employee's post code", "PostCode", out postCode))
        {
            emp.PostCode = postCode;
        }

        if (GetInput(departmentType, "Please enter the employee's department code", "DeptShortName", out deptShortName))
        {
            dept.DeptShortName = deptShortName;
        }

        Console.WriteLine();
        Console.BackgroundColor = ConsoleColor.DarkGreen;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"Thank you! Employee with first name, {emp.FirstName}, and Id, {emp.Id}, has been entered successfully!!");
        Console.ResetColor();
    }

    private static bool GetInput(Type t, string promptText, string fieldName, out string fieldValue)
    {
        fieldValue = "";
        string enteredValue = "";
        string errorMessage = null;
        do
        {
            Console.WriteLine(promptText);

            enteredValue = Console.ReadLine();

            if (!Validation.PropertyValueIsValid(t, enteredValue, fieldName, out errorMessage))
            {
                fieldValue = null;
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(errorMessage);
                Console.WriteLine();
                Console.ResetColor();
            }
            else
            {
                fieldValue = enteredValue;
                break;
            }


        }
        while (true);

        return true;
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

