// // 死锁
// using System;
// using System.Threading;
// class Program
// {
//     static void LockTooMuch(object lock1, object lock2)
//     {
//         lock (lock1)
//         {
//             Console.WriteLine("Got lock1");
//             Thread.Sleep(1000);
//             lock (lock2)
//             {
//                 Console.WriteLine("Got lock2");
//             }
//         }
//     }
//     static void Main()
//     {
//         object lock1 = new object();
//         object lock2 = new object();

//         new Thread(() => LockTooMuch(lock1, lock2)).Start();
//         lock (lock2)
//         {
//             Console.WriteLine("Got lock2");
//             Thread.Sleep(1000);
//             Console.WriteLine("Monitor.TryEnter returning false after a specified timeout is elapsed");
//             if (Monitor.TryEnter(lock1, TimeSpan.FromSeconds(5)))
//             {
//                 Console.WriteLine("Got lock1,(Acquired a protected resource successfully)");
//             }
//             else
//             {
//                 Console.WriteLine("Failed to get lock1, timeout expired,(Failed to acquire a protected resource within a specified time)");
//             }
//         }

//         Console.WriteLine("-------------------");
//         new Thread(() => LockTooMuch(lock1, lock2)).Start();
//         lock (lock2)
//         {
//             Console.WriteLine("This will be deadlocked");
//             Thread.Sleep(1000);
//             lock (lock1)
//             {
//                 Console.WriteLine("Acquired a protected resource successfully");
//             }
//         }
//     }
// }