// using System;
// using System.Collections.Concurrent;

// public class ConcurrentStackExample
// {
//     public static void Main()
//     {
//         var cs = new ConcurrentStack<int>();

//         // 入栈
//         cs.Push(1);
//         cs.Push(2);

//         // 出栈
//         if (cs.TryPop(out int result))
//         {
//             Console.WriteLine($"Popped: {result}");
//         }

//         // 查看栈顶元素
//         if (cs.TryPeek(out result))
//         {
//             Console.WriteLine($"Top item: {result}");
//         }
//     }
// }