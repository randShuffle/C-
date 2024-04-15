// using System;
// using System.Collections.Concurrent;

// public class ConcurrentDictionaryExample
// {
//     public static void Main()
//     {
//         var cd = new ConcurrentDictionary<int, string>();

//         // 添加元素
//         cd.TryAdd(1, "one");
//         cd.TryAdd(2, "two");

//         // 读取元素
//         if (cd.TryGetValue(1, out string value1))
//         {
//             Console.WriteLine($"Key 1: {value1}");
//         }

//         // 更新元素
//         cd.TryUpdate(1, "ONE", "one");

//         // 删除元素
//         cd.TryRemove(1, out string removedValue);

//         // 遍历字典
//         foreach (var kvp in cd)
//         {
//             Console.WriteLine($"Key {kvp.Key}: {kvp.Value}");
//         }
//     }
// }