using System;
using System.Runtime.CompilerServices;
using Serilog;
using Serilog.Core;

// ReSharper disable once CheckNamespace
namespace HidePathInExceptions
{
    partial class Program
    {
        private static readonly Logger Logger = new LoggerConfiguration()
            .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

        [ModuleInitializer]
        public static void Init()
        {



            Console.Title = "Exception without path code sample";
            WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
        }
    }
}





