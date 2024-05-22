// using System.Collections;  
  
// namespace  ConsoleApp1  
// {  
//     public class MyYield : IEnumerable  
//     {  
//         public int StartCount;  
//         public IEnumerator GetEnumerator()  
//         {  
//             for (int n = StartCount - 1; n >= 0; --n)  
//             {  
//                 yield return n;  
//             }  
//         }  
//     }  
//     class Program  
//     {  
//         static void Main(string[] args)  
//         {  
//             MyYield myYield = new MyYield{StartCount = 5};  
//             IEnumerator enumerator = myYield.GetEnumerator();  
//             while (enumerator.MoveNext())  
//             {  
//                 Console.WriteLine(enumerator.Current);  
//             }  
  
//             foreach (var i in myYield)  
//             {  
//                 Console.WriteLine(i);  
//             }  
//         }  
//     }  
// }