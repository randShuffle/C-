using System;
using System.Threading.Tasks;


namespace MethodWithTwoAwaits
{
    class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Main method started.");
        await MethodWithTwoAwaits();
        Console.WriteLine("Main method finished.");
    }

    static async Task MethodWithTwoAwaits()
    {
        Console.WriteLine("Starting async method with two awaits...");

        // First asynchronous call
        await Task.Delay(1000); // Simulates an async operation, e.g., fetching data
        Console.WriteLine("First await completed.");

        // Second asynchronous call
        await Task.Delay(2000); // Simulates another async operation
        Console.WriteLine("Second await completed.");

        Console.WriteLine("Async method finished.");
    }
}
}
