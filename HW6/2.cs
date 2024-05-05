// using System;  
  
// class Program  
// {  
//     static int WorkItem1(object o)  
//     {        
//         Console.WriteLine("Here1 is the object: {0}", o);  
//         return 1;  
//     }    
//     static void WorkItem2(Task<int> t)  
//     {   Console.WriteLine("Here2 is the object: {0}", t.Result);  

//     }  
//     static void Main(String[] args)  
//     {        
//         Task<int> ta = new Task<int>(WorkItem1, "Hello");  
//         Task tb = ta.ContinueWith(t=>WorkItem2(t));  
//         ta.Start();  
//         tb.Wait();  
//         Console.WriteLine("Main done");  
//     }  
// }