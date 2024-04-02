// // 使用互锁函数
// using System;
// using System.Threading;
// internal class Program
// {
//     abstract class CountBase
//     {
//         public abstract void Increment();
//         public abstract void Decrement();
//     }
//     class Counter : CountBase
//     {
//         public int _count = 0;
//         public override void Increment()
//         {
//             _count++;
//         }
//         public override void Decrement()
//         {
//             _count--;
//         }
//     }
//     class CounterNoLock : CountBase
//     {
//         public int _count = 0;
//         public override void Increment()
//         {
//             Interlocked.Increment(ref _count);
//         }
//         public override void Decrement()
//         {
//             Interlocked.Decrement(ref _count);
//         }
//     }
//     static void TestCounter(CountBase c)
//     {
//         for (int i = 0; i < 1000000; i++)
//         {
//             c.Increment();
//             c.Decrement();
//         }
//     }
//     static void Main()
//     {
//         Console.WriteLine("Incorrect Counter");
//         var counter = new Counter();
//         var t1 = new Thread(() => TestCounter(counter));
//         var t2 = new Thread(() => TestCounter(counter));
//         var t3 = new Thread(() => TestCounter(counter));
//         t1.Start();
//         t2.Start();
//         t3.Start();
//         t1.Join();
//         t2.Join();
//         t3.Join();
//         Console.WriteLine("Count: {0}", counter._count);

//         Console.WriteLine("----------------------");

//         Console.WriteLine("Counter with Interlocked");
//         var counterNoLock = new CounterNoLock();
//         var t4 = new Thread(() => TestCounter(counterNoLock));
//         var t5 = new Thread(() => TestCounter(counterNoLock));
//         var t6 = new Thread(() => TestCounter(counterNoLock));
//         t4.Start();
//         t5.Start();
//         t6.Start();
//         t4.Join();
//         t5.Join();
//         t6.Join();
//         Console.WriteLine("Count: {0}", counterNoLock._count);

//     }
// }