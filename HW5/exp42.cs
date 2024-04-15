// using System;
// using System.Collections.Concurrent;

// public class ConcurrentQueueExample
// {
//     public static void Main()
//     {
//         var cq = new ConcurrentQueue<int>();

//         // 入队
//         cq.Enqueue(1);
//         cq.Enqueue(2);

//         // 出队
//         if (cq.TryDequeue(out int result))
//         {
//             Console.WriteLine($"Dequeued: {result}");
//         }

//         // 查看队首元素
//         if (cq.TryPeek(out result))
//         {
//             Console.WriteLine($"Front item: {result}");
//         }
//     }
// }