// using System;

// class Program
// {
//     static int WorkItem1(object o)
//     {
//         Console.WriteLine("Here1 is the object: {0}", o);
//         return 1;
//     }
//     static async Task WorkItemAsync()
//     {
//         Console.WriteLine("WorkItem2 Begin");
//         Task<int> ta = new Task<int>(WorkItem1, 100);
//         ta.Start();
//         var result = await ta;
//         Console.WriteLine("Here2 is the object: {0}", result);
//     }
//     static void Main(String[] args)
//     {
//         Task t = WorkItemAsync();
//         t.Wait();
//         Console.WriteLine("Main done");
//     }
// }