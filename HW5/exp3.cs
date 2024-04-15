// using System;
// using System.Collections.Concurrent;
// using System.Diagnostics;
// using System.Threading;

// class ConcurrentDictionaryPerformanceTest
// {
//     private static ConcurrentDictionary<int, int> concurrentDictionary = new ConcurrentDictionary<int, int>();
//     private static int itemCount = 100000; // 操作的项目数量

//     static void Main(string[] args)
//     {
//         Stopwatch stopwatch = new Stopwatch();
        
//         // 单线程测试
//         stopwatch.Start();
//         PerformDictionaryOperations();
//         stopwatch.Stop();
//         Console.WriteLine($"单线程操作耗时: {stopwatch.ElapsedMilliseconds} ms");

//         concurrentDictionary.Clear(); // 清空字典准备多线程测试

//         // 多线程测试
//         stopwatch.Restart();
//         Thread[] threads = new Thread[6];
//         for (int i = 0; i < threads.Length; i++)
//         {
//             threads[i] = new Thread(PerformDictionaryOperations);
//             threads[i].Start();
//         }

//         foreach (var thread in threads)
//         {
//             thread.Join(); // 等待所有线程完成
//         }
//         stopwatch.Stop();
//         Console.WriteLine($"多线程操作耗时: {stopwatch.ElapsedMilliseconds} ms");
//     }

//     static void PerformDictionaryOperations()
//     {
//         for (int i = 0; i < itemCount; i++)
//         {
//             concurrentDictionary.TryAdd(i, i);
//         }
//         for (int i = 0; i < itemCount; i++)
//         {
//             concurrentDictionary.TryGetValue(i, out int value);
//         }
//         for (int i = 0; i < itemCount; i++)
//         {
//             concurrentDictionary.TryRemove(i, out int value);
//         }
//     }
// }