// // 创建线程
// using System;
// using System.Threading;
// class Program
// {
//     static void Main()
//     {
//         Thread t = new Thread(PrintNumbers);
//         t.Start();
//         PrintNumbers();
//     }
//     static void PrintNumbers()
//     {
//         Console.WriteLine("Starting...");
//         for (int i = 1; i <= 10; i++)
//         {
//             Console.WriteLine(i);
//         }
//     }
// }