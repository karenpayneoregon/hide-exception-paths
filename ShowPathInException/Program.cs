using Serilog.Events;
using ShowPathInException.Classes;

namespace ShowPathInException;

internal partial class Program
{
    static async Task Main(string[] args)
    {
        await Task.Delay(0);

        try
        {
            await foreach (var item in DataOperations.GetData(true))
            {
                Console.WriteLine(item);
            }
        }
        catch (Exception localException)
        {
            Console.WriteLine(localException);
            var test = localException.FlattenHierarchy();
            var rule = new Rule();
            AnsiConsole.Write(rule);

            foreach (var exception in test)
            {
                Logger.Write(LogEventLevel.Error, localException, "Woops");
                Console.WriteLine(exception.Message);
                Console.WriteLine();
            }


        }

        Console.ReadLine();

    }


}