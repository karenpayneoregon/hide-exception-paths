using System.Runtime.CompilerServices;
using Serilog;
using Serilog.Core;

// ReSharper disable once CheckNamespace
namespace ShowPathInException;

internal partial class Program
{
    private static readonly Logger Logger = new LoggerConfiguration()
        .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
        .CreateLogger();

    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "Exception with path code sample - with Serilog";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }
}