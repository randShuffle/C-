using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

public class BlockingCollectionExample
{
    public static void Main()
    {
        var bc = new BlockingCollection<int>(boundedCapacity: 2);

        // 生产者任务
        Task producer = Task.Run(() =>
        {
            for (int i = 0; i < 5; i++)
            {
                bc.Add(i);
                Console.WriteLine($"Added {i}");
            }
            bc.CompleteAdding();
        });

        // 消费者任务
        Task consumer = Task.Run(() =>
        {
            while (!bc.IsCompleted)
            {
                if (bc.TryTake(out int item, TimeSpan.FromSeconds(1)))
                {
                    Console.WriteLine($"Took {item}");
                }
            }
        });

        Task.WaitAll(producer, consumer);
    }
}