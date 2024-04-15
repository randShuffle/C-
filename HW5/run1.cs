// using System;
// using System.Threading;

// public class Program
// {
//     static void Main(string[] args)
//     {
//         const string MutexName = "CSharpThreadingMutex";
//         var m = new Mutex(false, MutexName);
//         try
//         {
//             if (!m.WaitOne(TimeSpan.FromSeconds(5)))
//             {
//                 System.Console.WriteLine("Second instance is running!");
//             }
//             else
//             {
//                 System.Console.WriteLine("Running!");
//                 System.Console.ReadLine();
//                 m.ReleaseMutex();
//             }
//         }
//         finally
//         {
//             m.Dispose();
//         }
//     }
// }
