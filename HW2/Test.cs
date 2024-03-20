// using System;
// class Test
// {
//     static void Main()
//     {
//         Console.WriteLine("Hello c#");
//         Type t = 7.GetType();
//         string s = 7.ToString();
//         Console.WriteLine("Type {0} {1}", t, s);
//         int i = 5;
//         System.Int32 k = 6;
//         uint kk = 70;
//         System.Char u = 'c';
//         Console.WriteLine("Type {0} {1}", u.GetType(), kk.GetType());
//         Console.WriteLine("Type {0} {1}", i, k);
//         int[] numbers = { 1, 2, 3, 4, 5 };
//         // numbers.Append(66);
//         Console.WriteLine("numbers {0} {1}", numbers.Length, numbers[3]);
//         const int nArray = 6;
//         int[] arr = new int[nArray];
//         int[] arr2 = new int[3] { 1, 2, 3 };
//         int[] arr3 = new int[nArray] { 1, 2, 3, 4, 5, 6 };
//         foreach (var v in arr3)
//         {
//             Console.WriteLine("Arr {0}", v);
//         }
//         string[] strArr =  {"fred","dela","nina"};
//         foreach (var v in strArr)
//         {
//             Console.WriteLine("Arr {0}", v);
//         }
//         for (int j = 0; j < strArr.Length; j++)
//         {
//             Console.WriteLine("Arr {0}", strArr[j]);
//         }
//             string[] ss = new string[4];
//         foreach (var item in ss)
//         {
//             //Console.WriteLine("Arr {0}", item.ToString());
//         }
//         int?[] intArr = { 1, 2, 3, null, 6 };
//         foreach (var item in intArr)
//         {
//             Console.WriteLine("int? {0}", item);
//         }
//         string sFred = "Fred";
//         if (sFred.ToLower() == "fred")
//         {
//             Console.WriteLine($"sFred {sFred}");
//         }
//     }
// }