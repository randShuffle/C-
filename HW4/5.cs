// // 线程运行状态
// using System;
// using System.Threading;
// class Program
// {
//     static void DoNotiong()
//     {
//         Thread.Sleep(TimeSpan.FromSeconds(2));
//     }
//     static void PrintNumberWithStatus()
//     {
//         Console.WriteLine("PrintNumberWithStatus starting...");
//         Console.WriteLine("Thread state: {0}", Thread.CurrentThread.ThreadState); // 理解底层实现逻辑
//         for (int i = 0; i < 10; i++)
//         {
//             Thread.Sleep(TimeSpan.FromSeconds(2));
//             Console.WriteLine(i);
//         }
//     }
//     static void Main()
//     {
//         Console.WriteLine("Start program...");
//         Thread t1 = new Thread(PrintNumberWithStatus);
//         Thread t2 = new Thread(DoNotiong);
//         Console.WriteLine("t1 state: {0}", t1.ThreadState);
//         t2.Start();
//         t1.Start();
//         for (int i = 0; i < 30; i++)
//         {
//             Console.WriteLine("t1 state: {0}, t2 state: {1}", t1.ThreadState, t2.ThreadState);
//         }
//         Thread.Sleep(TimeSpan.FromSeconds(6));
//         t1.Abort();
//         Console.WriteLine("t1 thread has been aborted.");
//         Console.WriteLine("t1 state: {0}, t2 state: {1}", t1.ThreadState, t2.ThreadState);
//     }
// }