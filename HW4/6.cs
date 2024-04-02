// // 线程优先级
// using System;
// using System.Threading;
// using System.Diagnostics;
// class Program
// {
//     class ThreadSample
//     {
//         private bool _isStopped = false;
//         public void Stop()
//         {
//             _isStopped = true;
//         }
//         public void CountNumbers()
//         {
//             long counter = 0;
//             while (!_isStopped)
//             {
//                 counter++;
//             }
//             Console.WriteLine("{0} with {1,11} priority has a count = {2,13}", Thread.CurrentThread.Name, Thread.CurrentThread.Priority.ToString(), counter.ToString("N0"));
//         }
//     }
//     static void RunThreads()
//     {
//         var sample = new ThreadSample();
//         var threadOne = new Thread(sample.CountNumbers);
//         threadOne.Name = "ThreadOne";
//         var threadTwo = new Thread(sample.CountNumbers);
//         threadTwo.Name = "ThreadTwo";
//         threadOne.Priority = ThreadPriority.Highest;
//         threadTwo.Priority = ThreadPriority.Lowest;
//         threadOne.Start();
//         threadTwo.Start();
//         Thread.Sleep(TimeSpan.FromSeconds(2));
//         sample.Stop();
//     }
//     static void Main()
//     {
//         Console.WriteLine("Current thread priority: {0}", Thread.CurrentThread.Priority);
//         Console.WriteLine("Runing on all cores available");
//         RunThreads();
//         Thread.Sleep(TimeSpan.FromSeconds(2));
//         Console.WriteLine("Runing on a single core");
//         Process.GetCurrentProcess().ProcessorAffinity = new IntPtr(7); // 这里试试1，2，3，5，7
//         RunThreads();
//         Console.WriteLine("Main method complete.");
//     }
// }