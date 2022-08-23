using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using Serilog.Core;

// ReSharper disable once CheckNamespace
namespace ShowPathInException
{
    internal partial class Program
    {
        private static readonly Logger Logger = new LoggerConfiguration()
            .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

        [ModuleInitializer]
        public static void Init()
        {
            Console.Title = "Exception with path code sample";
            WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
        }
    }
}
