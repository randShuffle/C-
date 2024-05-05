// using System;
// using System.Threading.Tasks;
// using static System.Console;
// using static System.Threading.Thread;

// class Program
// {
//     static int TaskMethod(string name)
//     {
//         WriteLine($"Task 【{name}】 is running on a thread id " +
//                   $"{CurrentThread.ManagedThreadId}. Is thread pool thread: " +
//                   $"{CurrentThread.IsThreadPoolThread}");
//         Sleep(TimeSpan.FromSeconds(2));
//         return 42;
//     }
//     static Task<int> CreateTask(string name)
//     {
//         return new Task<int>(() => TaskMethod(name));
//     }
//     static void Main(string[] args)
//     {        //(1)在主线程直接调用方法  
//         TaskMethod("Main Thread Task");
//         WriteLine("");

//         //(2)创建一个任务,然后正常执行，得到结果  
//         Task<int> task = CreateTask("Task 1");
//         task.Start();
//         int result = task.Result;
//         WriteLine($"Result is: {result}\r\n");
//         //return;  

//         //(3)创建任务,使用RunSynchronously进行执行,得到结果  
//         task = CreateTask("Task 2");
//         task.RunSynchronously();
//         result = task.Result;
//         WriteLine($"Result is: {result}\r\n");

//         //(4)观察任务的运行状态  
//         task = CreateTask("Task 3");
//         WriteLine(task.Status);
//         task.Start();
//         while (!task.IsCompleted)
//         {
//             WriteLine(task.Status);
//             Sleep(TimeSpan.FromSeconds(0.5));
//         }
//         WriteLine(task.Status);
//         result = task.Result;
//         WriteLine($"Result is: {result}");
//     }
// }