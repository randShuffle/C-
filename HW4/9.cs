// // 使用线程局部存储
// using System;
// using System.Threading;
// class Program
// {
//      [ThreadStatic] // 要是没有这个，那么counterPerThread就会变成共享的，又因为没有加锁，所以会出现问题
//     static int counterPerThread = 0;
//     static void PrintNumbers()
//     {
//         for (int i = 0; i < 500000; i++)
//         {
//             counterPerThread++;
//         }
//         Console.WriteLine("Thread:{0}, Counter:{1}", Thread.CurrentThread.ManagedThreadId, counterPerThread);
//     }
//     static void Main()
//     {
//         Thread t1 = new Thread(PrintNumbers);
//         t1.Start();
//         PrintNumbers();
//     }
// }