// using System;
// using System.Threading;

// class MutexExperiment
// {
//     private static Mutex mutex;

//     static void Main(string[] args)
//     {
//         mutex = new Mutex(false, "TestMutex");

//         // 启动线程A
//         Thread threadA = new Thread(ThreadA);
//         threadA.Start();
//         threadA.Join(); // 等待线程A结束

//         // 启动线程B
//         Thread threadB = new Thread(ThreadB);
//         threadB.Start();
//         threadB.Join(); // 等待线程B结束
//     }

//     static void ThreadA()
//     {
//         Console.WriteLine("线程A: 尝试获取互斥体");
//         mutex.WaitOne(); // 获取互斥体
//         Console.WriteLine("线程A: 成功获取互斥体，模拟工作但不释放互斥体后结束");
//         // 注意：这里不调用 mutex.ReleaseMutex();
//         // 线程A结束，没有释放互斥体
//     }

//     static void ThreadB()
//     {
//         Console.WriteLine("线程B: 尝试获取互斥体");
//         bool gotMutex = mutex.WaitOne(TimeSpan.FromSeconds(5)); // 尝试获取互斥体，等待最多5秒

//         if (gotMutex)
//         {
//             Console.WriteLine("线程B: 成功获取互斥体");
//             mutex.ReleaseMutex(); // 释放互斥体
//         }
//         else
//         {
//             Console.WriteLine("线程B: 获取互斥体超时");
//         }
//     }
// }