using System;
using System.Threading;

namespace Synchronization
{
    class Program
    {
        static readonly SharedExclusiveLock sharedExclusiveLock = new SharedExclusiveLock();
        static readonly int readerCount = 5;
        static readonly int writerCount = 2;
        
        static void Main(string[] args)
        {
            // Start reader threads.
            for (int i = 0; i < readerCount; i++)
            {
                Thread readerThread = new Thread(ReaderThread) { Name = $"Reader-{i+1}" };
                readerThread.Start();
            }
            
            // Start writer threads.
            for (int i = 0; i < writerCount; i++)
            {
                Thread writerThread = new Thread(WriterThread) { Name = $"Writer-{i+1}" };
                writerThread.Start();
            }
            
            Console.ReadKey();
        }

        static void ReaderThread()
        {
            while (true)
            {
                sharedExclusiveLock.LockShared();
                Console.WriteLine($"{Thread.CurrentThread.Name} has acquired the shared lock.");
                // Simulate reading activity.
                Thread.Sleep(100);
                Console.WriteLine($"{Thread.CurrentThread.Name} has released the shared lock.");
                sharedExclusiveLock.UnlockShared();
                
                // Simulate time between reading.
                Thread.Sleep(1000);
            }
        }

        static void WriterThread()
        {
            while (true)
            {
                sharedExclusiveLock.LockExclusive();
                Console.WriteLine($"{Thread.CurrentThread.Name} has acquired the exclusive lock.");
                // Simulate writing activity.
                Thread.Sleep(500);
                Console.WriteLine($"{Thread.CurrentThread.Name} has released the exclusive lock.");
                sharedExclusiveLock.UnlockExclusive();
                
                // Simulate time between writing.
                Thread.Sleep(2000);
            }
        }
    }
    
  
}