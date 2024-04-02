// // 使用Monitor Lock（分析错误的原因）
// using System;
// using System.Threading;
// class Program
// {
//     abstract class CountBase
//     {
//         public abstract void Increment();
//         public abstract void Decrement();
//     }
//     class Count : CountBase
//     {
//         private int _count { get; set; }
//         public override void Increment()
//         {
//             _count++;
//         }
//         public override void Decrement()
//         {
//             _count--;
//         }
//         public int GetCount()
//         {
//             return _count;
//         }
//     }
//     class CounterWithMonitor : CountBase
//     {
//         private readonly object _syncRoot = new object();
//         public int _count { get; private set; }
//         public override void Increment()
//         {
//             bool lockTaken = false;
//             try
//             {
//                 Monitor.Enter(_syncRoot, ref lockTaken);
//                 _count++;
//             }
//             finally
//             {
//                 if (lockTaken)
//                 {
//                     Monitor.Exit(_syncRoot);
//                 }
//             }
//         }
//         public override void Decrement()
//         {
//             bool lockTaken = false;
//             try
//             {
//                 Monitor.Enter(_syncRoot, ref lockTaken);
//                 _count--;
//             }
//             finally
//             {
//                 if (lockTaken)
//                 {
//                     Monitor.Exit(_syncRoot);
//                 }
//             }
//         }
//     }
//     class CounterWithLock : CountBase
//     {
//         private readonly object _syncRoot = new object();
//         public int _count { get; private set; }
//         public override void Increment()
//         {
//             lock (_syncRoot)
//             {
//                 _count++;
//             }
//         }
//         public override void Decrement()
//         {
//             lock (_syncRoot)
//             {
//                 _count--;
//             }
//         }
//     }
//     static void TestCounter(CountBase counter)
//     {
//         for (int i = 0; i < 100000; i++)
//         {
//             counter.Increment();
//             counter.Decrement();
//         }
//     }
//     static void Main()
//     {
//         Console.WriteLine("Incorrect counter");
//         var counter = new Count();
//         var thread1 = new Thread(() => TestCounter(counter));
//         var thread2 = new Thread(() => TestCounter(counter));
//         var thread3 = new Thread(() => TestCounter(counter));
//         thread1.Start();
//         thread2.Start();
//         thread3.Start();
//         thread1.Join();
//         thread2.Join();
//         thread3.Join();
//         Console.WriteLine("Count: {0}", counter.GetCount());

//         Console.WriteLine("Counter with Monitor");
//         var counterWithMonitor = new CounterWithMonitor();
//         var thread4 = new Thread(() => TestCounter(counterWithMonitor));
//         var thread5 = new Thread(() => TestCounter(counterWithMonitor));
//         var thread6 = new Thread(() => TestCounter(counterWithMonitor));
//         thread4.Start();
//         thread5.Start();
//         thread6.Start();
//         thread4.Join();
//         thread5.Join();
//         thread6.Join();
//         Console.WriteLine("Count: {0}", counterWithMonitor._count);

//         Console.WriteLine("Counter with Lock");
//         var counterWithLock = new CounterWithLock();
//         var thread7 = new Thread(() => TestCounter(counterWithLock));
//         var thread8 = new Thread(() => TestCounter(counterWithLock));
//         var thread9 = new Thread(() => TestCounter(counterWithLock));
//         thread7.Start();
//         thread8.Start();
//         thread9.Start();
//         thread7.Join();
//         thread8.Join();
//         thread9.Join();
//         Console.WriteLine("Count: {0}", counterWithLock._count);
//     }
// }