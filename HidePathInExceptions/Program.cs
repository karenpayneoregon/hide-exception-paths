using System;
using System.Text;
using System.Threading.Tasks;
using HidePathInExceptions.Classes;
using Serilog.Events;
using Spectre.Console;

namespace HidePathInExceptions;

internal partial class Program
{
    static async Task Main(string[] args)
    {
        await Task.Delay(0);
        StringBuilder builder = new StringBuilder();
        try
        {

            await AnsiConsole.Progress()
                .Columns(
                    new TaskDescriptionColumn(), 
                    new PercentageColumn(), 
                    new SpinnerColumn())
                .StartAsync(async ctx =>
                {

                    var task1 = ctx.AddTask("[white]Reading data[/]");

                    while (!ctx.IsFinished)
                    {

                        await foreach (var item in DataOperations.GetData(true, false))
                        {
                            builder.AppendLine(item);
                            task1.Increment(1);
                        }
                    }
                });

            AnsiConsole.MarkupLine("[cyan]finished[/]");

        }
        catch (Exception localException)
        {
            //Console.WriteLine(localException);
            ExceptionHelpers.ColorStandard(localException);
            Logger.Write(LogEventLevel.Error,localException,"Woops");
            var test = localException.FlattenHierarchy();
        }

        Console.ReadLine();

    }

       
}