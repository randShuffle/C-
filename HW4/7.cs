// // 前后台线程
// using System;
// using System.Threading;
// class Program
// {
//     static void Main()
//     {
//         var sampleForeground = new ThreadSample(10);
//         var sampleBackground = new ThreadSample(20);
//         var threadOne = new Thread(sampleForeground.CountNumbers);
//         threadOne.Name = "ForegroundThread";
//         var threadTwo = new Thread(sampleBackground.CountNumbers);
//         threadTwo.Name = "BackgroundThread";
//         threadTwo.IsBackground = true; // 当主线程结束时，后台线程会被终止。
//         // IsBackground属性用于控制线程的生命周期。通过将线程设置为后台线程，可以使应用程序在主线程结束时更容易退出，而无需等待后台线程完成。
//         threadOne.Start();
//         threadTwo.Start();
//         // threadTwo.Join(); // 等待后台线程结束 这里是我自己加的
//     }
//     class ThreadSample
//     {
//         private readonly int _iterations;
//         public ThreadSample(int iterations)
//         {
//             _iterations = iterations;
//         }
//         public void CountNumbers()
//         {
//             for (int i = 0; i < _iterations; i++)
//             {
//                 Thread.Sleep(TimeSpan.FromSeconds(0.5));
//                 Console.WriteLine("{0} prints {1}", Thread.CurrentThread.Name, i);
//             }
//         }
//     }
// }