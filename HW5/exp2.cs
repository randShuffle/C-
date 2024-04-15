// using System;
// using System.Threading;

// class ReaderWriterLockSlimExperiment
// {
//     private static ReaderWriterLockSlim rwLock = new ReaderWriterLockSlim();
//     private static int sharedResource = 0;

//     static void Main(string[] args)
//     {
//         // 启动读线程
//         Thread[] readers = new Thread[5];
//         for (int i = 0; i < readers.Length; i++)
//         {
//             readers[i] = new Thread(ReadResource);
//             readers[i].Start();
//         }

//         // 启动写线程
//         Thread writer = new Thread(WriteResource);
//         writer.Start();

//         // 启动可升级读线程
//         Thread upgradableReader = new Thread(UpgradeableReadResource);
//         upgradableReader.Start();

//         foreach (var reader in readers)
//         {
//             reader.Join();
//         }

//         writer.Join();
//         upgradableReader.Join();
//     }

//     static void ReadResource()
//     {
//         rwLock.EnterReadLock();
//         try
//         {
//             Console.WriteLine($"读线程{Thread.CurrentThread.ManagedThreadId}: 读取资源值 {sharedResource}");
//             Thread.Sleep(100); // 模拟读取操作
//         }
//         finally
//         {
//             rwLock.ExitReadLock();
//         }
//     }

//     static void WriteResource()
//     {
//         rwLock.EnterWriteLock();
//         try
//         {
//             Console.WriteLine($"写线程{Thread.CurrentThread.ManagedThreadId}: 修改资源值");
//             sharedResource = new Random().Next(100); // 模拟写操作
//             Thread.Sleep(100); // 模拟写操作
//         }
//         finally
//         {
//             rwLock.ExitWriteLock();
//         }
//     }

//     static void UpgradeableReadResource()
//     {
//         rwLock.EnterUpgradeableReadLock();
//         try
//         {
//             Console.WriteLine($"可升级读线程{Thread.CurrentThread.ManagedThreadId}: 读取资源值 {sharedResource}");
//             if (sharedResource < 50) // 条件判断，决定是否需要写操作
//             {
//                 rwLock.EnterWriteLock();
//                 try
//                 {
//                     Console.WriteLine($"可升级读线程{Thread.CurrentThread.ManagedThreadId}: 升级为写锁，修改资源值");
//                     sharedResource = new Random().Next(100); // 模拟写操作
//                     Thread.Sleep(100); // 模拟写操作
//                 }
//                 finally
//                 {
//                     rwLock.ExitWriteLock();
//                 }
//             }
//             Thread.Sleep(100); // 模拟读取操作
//         }
//         finally
//         {
//             rwLock.ExitUpgradeableReadLock();
//         }
//     }
// }