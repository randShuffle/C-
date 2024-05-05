// using System;
// using System.Threading.Tasks;
// using static System.Console;
// using static System.Threading.Thread;

// class Program
// {
//     static void TaskMethod(string name)
//     {
//         WriteLine($"Task {name} is running on a thread id " +
//                   $"{CurrentThread.ManagedThreadId}. Is thread pool thread: " +
//                   $"{CurrentThread.IsThreadPoolThread}");
//     }

//     static string TaskMethod2(string name)
//     {
//         return name + 500.ToString();
//     }

//     static void Main(string[] args)
//     {
//         //方式1: 创建任务对象并且启动,如果不调用Start，任务不会被执行
//         var t1 = new Task(() => TaskMethod("Task 1"));
//         var t2 = new Task(() => TaskMethod("Task 2"));
//         t2.Start();
//         t1.Start();

//         //方式2: 创建任务并自动立即开始执行，可以提供一个参数
//         Task.Factory.StartNew(() => TaskMethod("Task 3"));

//         //标记为长时间运行的任务将不会使用线程池，而在单独的线程中运行
//         Task.Factory.StartNew(() => TaskMethod("Task 4"), TaskCreationOptions.LongRunning);
//         //方式3: Task.Run是Task.Factory.StartNew的一个快捷方式
//         Task.Run(() => TaskMethod("Task 5"));

//         Task<string> t3 = Task.Run(() => TaskMethod2("Task 6 "));
//         //t3.Wait();
//         WriteLine($"TaskMethod2 result: {t3.Result}");

//         Sleep(TimeSpan.FromSeconds(1));
//     }
// }