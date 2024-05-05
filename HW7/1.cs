// using System;
// using System.Threading.Tasks;

// namespace ContinueWith
// {
//     class Program
//     {
//         static int WorkItem1(object o)
//         {
//             Console.WriteLine("Here1 {0}", o);
//             return 1000;
//         }

//         static async Task WorkItemAsync()
//         {
//             Console.WriteLine("WorkItem2 Begin");
//             Task<int> ta = new Task<int>(WorkItem1, 200);
//             ta.Start();
//             int result = await ta.ConfigureAwait(false);
//             Console.WriteLine("Here2 {0}", result);
//         }

//         static void Main(string[] args)
//         {
//             Task t = Task.Run(() => WorkItemAsync());
//             t.ContinueWith(_ => Console.WriteLine("End"));
//             t.Wait();
//         }
//     }
// }
