// // 等待线程结束
// using System;
// using System.Threading;
// class Program
// {
//     static void Main()
//     {
//         Thread t = new Thread(PrintNumbersWithDelay);
//         t.Start();
//         t.Join();
//         Console.WriteLine("Thread t has ended!");
//     }
//     static void PrintNumbers()
//     {
//         Console.WriteLine("PrintNumbers Starting...");
//         for (int i = 1; i <= 10; i++)
//         {
//             Console.WriteLine(i);
//         }
//     }
//     static void PrintNumbersWithDelay()
//     {
//         Console.WriteLine("PrintNumbersWithDelay Starting...");
//         for (int i = 1; i <= 10; i++)
//         {
//             Thread.Sleep(TimeSpan.FromSeconds(2));
//             Console.WriteLine(i);
//         }
//     }

// }