
using System;
using System.Threading.Tasks;
using HidePathInExceptions.Classes;
using Serilog.Events;

namespace HidePathInExceptions
{
    internal partial class Program
    {
        static async Task Main(string[] args)
        {
            await Task.Delay(0);

            try
            {
                await foreach (var item in DataOperations.GetData(true, false))
                {
                    Console.WriteLine(item);
                    
                }
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
}