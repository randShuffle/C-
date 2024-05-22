// namespace  ConsoleApp1  
// {  
//     class Program  
//     {  
//         static void Main(string[] args)  
//         {  
//             string[] greetings = { "Hello", "hello LINQ", "how are you" };  
//             var items = from s in greetings  
//                 where s.Length > 5  
//                 select s;  
//             foreach (var item in items)  
//             {  
//                 Console.WriteLine(item);  
//             }  
//             Console.ReadLine();  
//         }  
//     }  
// }