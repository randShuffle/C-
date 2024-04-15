// using System;
// using System.Collections.Concurrent;

// public class ConcurrentBagExample
// {
//     public static void Main()
//     {
//         var cb = new ConcurrentBag<int>();

//         // 添加元素
//         cb.Add(1);
//         cb.Add(2);

//         // 尝试取出
//         if (cb.TryTake(out int result))
//         {
//             Console.WriteLine($"Took: {result}");
//         }

//         // 查看一个元素
//         if (cb.TryPeek(out result))
//         {
//             Console.WriteLine($"Peeked item: {result}");
//         }
//     }
// }