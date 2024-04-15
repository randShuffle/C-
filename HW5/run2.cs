// using System;
// using System.Threading;
// public class Program

// {
//     static SemaphoreSlim _semaphore = new SemaphoreSlim(4); // 初始化信号量为4
//     static void AccessDatabase(string name, int seconds)
//     {
//         System.Console.WriteLine("{0} waits to access a database", name);
//         _semaphore.Wait(); // 信号量减1, 等待访问数据库
//         System.Console.WriteLine("{0} was granted an access to a database", name);
//         Thread.Sleep(TimeSpan.FromSeconds(seconds));
//         System.Console.WriteLine("{0} is completed", name);
//         _semaphore.Release(); // 信号量加1
//     }
//     public static void Main(string[] args)
//     {
//         WaitHandle[] arr = new WaitHandle[] { new AutoResetEvent(true), new AutoResetEvent(false) };
//         // 第一个自动重置事件已经触发，第二个自动重置事件未触发
//         System.Console.WriteLine("Please wait for the database to be initialized...");
//         WaitHandle.WaitAll(arr); // 阻塞等待所有自动重置事件出发
//         for (int i = 1; i <= 6; i++)
//         {
//             string threadName = "Thread " + i;
//             int secondsToWait = 1 + 1 * i;
//             var t = new Thread(() => AccessDatabase(threadName, secondsToWait));
//             t.Start();
//         }
//     }
// }