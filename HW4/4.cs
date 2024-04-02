// // 终止线程
// using System;
// using System.Threading;
// class Program
// {
//     static void PrintNumberWithDelay()
//     {
//         Console.WriteLine("PrintNumberWithDelay starting...");
//         try
//         {
//             for (int i = 0; i < 10; i++)
//             {
//                 Thread.Sleep(TimeSpan.FromSeconds(2));
//                 Console.WriteLine(i);
//             }
//         }
//         catch (ThreadAbortException)
//         {
//             Console.WriteLine("PrintNumberWithDelay is being aborted");
//             Thread.ResetAbort(); // 重置线程的中止状态
//         }
//         finally
//         {
//             Console.WriteLine("PrintNumberWithDelay is done! Exit code is 1");
//         }
//         Console.WriteLine("PrintNumberWithDelay is done! Exit code is 2");
//     }
//     static void Main()
//     {
//         Console.WriteLine("Main thread: starting a dedicated thread to do an asynchronous operation");
//         Thread t = new Thread(PrintNumberWithDelay);
//         t.Start();
//         Thread.Sleep(TimeSpan.FromSeconds(6));
//         t.Abort();
//         t.Join();
//         Console.WriteLine("Main thread is done!");
//     }
// }