// using System.Collections;  
  
// namespace  ConsoleApp1  
// {  
//     class Program  
//     {  
//         static void Main(string[] args)  
//         {  
//             string[] strArray ={ "one", "two", "three", "four", "five" ,"six", "seven", "eight", "nine", "ten" };  
//             // (1) 返回一个序列对象  
//             IEnumerable<string> items = strArray.Where(p => p.StartsWith('t'));  
//             foreach (var item in items)  
//             {  
//                 Console.WriteLine(item);  
//             }  
//             Console.WriteLine("1.  =======================================");  
//             // (2) 延迟执行  
//             strArray[2] = "t5000";  
//             foreach (var item in items)  
//             {  
//                 Console.WriteLine(item);  
//             }  
//             Console.WriteLine("2.  =======================================");  
//             // (3) 非延迟执行  
//             IEnumerable<string> item2 = strArray.Where(p => p.StartsWith('t')).ToList();  
//             foreach (var item in item2)  
//             {  
//                 Console.WriteLine(item);  
//             }  
//             strArray[2] = "t6000";  
//             foreach (var item in item2)  
//             {  
//                 Console.WriteLine(item);  
//             }  
//             Console.WriteLine("3.  =======================================");  
//             // (4) 查看定义  
//             // public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)  
//             // public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predicate)            // (5) 使用where的第二个原型  
//             IEnumerable<string> item3 = strArray.Where((p, i) =>  
//             {  
//                 if (i > 2)  
//                 {  
//                     return p.StartsWith('t');  
//                 }  
//                 else  
//                 {  
//                     return false;  
//                 }  
//             });  
//             foreach (var item in item3)  
//             {  
//                 Console.WriteLine(item);  
//             }  
//             Console.WriteLine("5.  =======================================");  
//             // (6) select  
//             IEnumerable<int> item4 = strArray.Select(p => p.Length);  
//             foreach (var item in item4)  
//             {  
//                 Console.WriteLine(item);  
//             }  
//             Console.WriteLine("6.  =======================================");  
//             // (7) select  
//             var item5 = strArray.Select((p,i)=>new {Index = i,Name= p});  
//             foreach (var item in item5)  
//             {  
//                 Console.WriteLine(item);  
//             }  
//             Console.WriteLine("7.  =======================================");  
//             // (8) selectMany  
//             var items6 = strArray.SelectMany(p => p.ToCharArray());  
//             foreach (var item in items6)  
//             {  
//                 Console.WriteLine(item);  
//             }  
//             Console.WriteLine("8.  =======================================");  
//             // (9) Take  
//             var items7 = strArray.Take(3);  
//             foreach (var item in items7)  
//             {  
//                 Console.WriteLine(item);  
//             }  
//             Console.WriteLine("9.  =======================================");  
//             // (10) TakeWhile  
//             var items8 = strArray.TakeWhile(p => p.Length <= 4);  
//             foreach (var item in items8)  
//             {  
//                 Console.WriteLine(item);  
//             }  
//             Console.WriteLine("10. =======================================");  
//             // (11) Skip  
//             var items9 = strArray.Skip(3);  
//             foreach (var item in items9)  
//             {  
//                 Console.WriteLine(item);  
//             }  
//             Console.WriteLine("11. =======================================");  
//             // (12) SkipWhile  
//             var items10 = strArray.SkipWhile(p => p.Length < 4);  
//             foreach (var item in items10)  
//             {  
//                 Console.WriteLine(item);  
//             }  
//             Console.WriteLine("12. =======================================");  
//             // (13) order by  
//             var items11 = strArray.OrderBy(p => p.Length);  
//             foreach (var item in items11)  
//             {  
//                 Console.WriteLine(item);  
//             }  
//             Console.WriteLine("13. =======================================");  
//             var items12 = strArray.OrderBy(p => p.Length).Take(5);  
//             foreach (var item in items11)  
//             {  
//                 Console.WriteLine(item);  
//             }  
//             Console.WriteLine("14. =======================================");  
//         }  
//     }  
// }