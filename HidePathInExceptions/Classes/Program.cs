using System;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Core;

// ReSharper disable once CheckNamespace
namespace HidePathInExceptions
{
    partial class Program
    {
        private static Logger Logger;

        [ModuleInitializer]
        public static void Init()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            Console.Title = "Exception without path code sample with Serilog/Spectre.Console";
            WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
        }
    }
}