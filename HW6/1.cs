// using System;  
  
// class Program  
// {  
//     static void WorkItem(object o)  
//     {        Console.WriteLine("Here is the object: {0}", o);  
//     }  
//     static void Main(String[] args)  
//     {        ThreadPool.QueueUserWorkItem(WorkItem, 100);  
//         Console.WriteLine("at main1");  
//         Thread.Sleep(1000);  
  
//         Task t = new Task(WorkItem, 200);  
//         t.Start();  
//         Console.WriteLine("at main2");  
//         t.Wait();  
//         Console.WriteLine("Main thread is done.");  
//     }  
// }