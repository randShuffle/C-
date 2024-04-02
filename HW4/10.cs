// // 线程函数要处理异常
// using System;
// using System.Threading;
// class Prigram
// {
//     static void BadFaultyThread()
//     {
//         Console.WriteLine("Starting a faulty thread...");
//         Thread.Sleep(TimeSpan.FromSeconds(2));
//         throw new Exception("Boom!");
//     }
//     static void FaultyThread()
//     {
//         try
//         {
//             Console.WriteLine("Starting a faulty thread...");
//             Thread.Sleep(TimeSpan.FromSeconds(1));
//             throw new Exception("Boom!");
//         }
//         catch (Exception ex)
//         {
//             Console.WriteLine("Exception handled: {0}", ex.Message);
//         }
//     }
//     static void Main()
//     {
//         var t = new Thread(FaultyThread);
//         t.Start();
//         t.Join();
//         Console.WriteLine("----------------");
//         // 无法捕获到新线程里面的异常
//         try
//         {
//             var badThread = new Thread(BadFaultyThread);
//             badThread.Start();
//             badThread.Join();
//         }
//         catch (Exception ex)
//         {
//             Console.WriteLine("We won't get here!");
//         }
//         // 异常导致进程结束，这里无法执行
//         Console.WriteLine("Main end.");
//     }
// }