// // 向线程传递参数
// using System;
// using System.Threading;
// class Program
// {
//     class ThreadSample
//     {
//         private readonly int _iterations;
//         public ThreadSample(int iterations)
//         {
//             _iterations = iterations;
//         }
//         public void CountNumbers()
//         {
//             for (int i = 1; i <= _iterations; i++)
//             {
//                 Thread.Sleep(TimeSpan.FromSeconds(0.5));
//                 Console.WriteLine("{0} prints {1}", Thread.CurrentThread.Name, i);
//             }
//         }
//     }
//     static void Count(object iterations)
//     {
//         CountNumbers((int)iterations);
//     }
//     static void CountNumbers(int iterations)
//     {
//         for (int i = 1; i <= iterations; i++)
//         {
//             Thread.Sleep(TimeSpan.FromSeconds(0.5));
//             Console.WriteLine("{0} prints {1}", Thread.CurrentThread.Name, i);
//         }
//     }
//     // 使用ref传递参数
//     static void PrintNumbers(int number)
//     {
//         Console.WriteLine(number++);
//     }
//     static void Main()
//     {
//         var sample = new ThreadSample(10);
//         var threadOne = new Thread(sample.CountNumbers);
//         threadOne.Name = "ThreadOne";
//         threadOne.Start();
//         threadOne.Join();

//         Console.WriteLine("-----------------");

//         var threadTwo = new Thread(Count);
//         threadTwo.Name = "ThreadTwo";

//         threadTwo.Start(8);
//         threadTwo.Join();

//         Console.WriteLine("-----------------");

//         var threadThree = new Thread(() => PrintNumbers(12));
//         threadThree.Name = "ThreadThree";
//         threadThree.Start();
//         threadThree.Join();

//         Console.WriteLine("-----------------");

//         int number = 10;
//         var threadFour = new Thread(() => PrintNumbers(number));
//         number = 20;
//         var threadFive = new Thread(() => PrintNumbers(number));
//         threadFour.Name = "ThreadFour";
//         threadFive.Name = "ThreadFive";
//         threadFour.Start();
//         threadFive.Start();

//         Console.WriteLine("-----------------");
//     }
//     // 使用out参数实验
//     static void TestOut(out int o)
//     {
//         o = 10;
//         // 使用未赋值的参数
//         // 所有路径都需要设定
//         // int n = o;
//         // o=1;
//     }

//     // 参数数组
//     static void AnyNumberInts(params int[] intArray)
//     {
//         Console.WriteLine("Number of ints: {0}", intArray.Length);
//         foreach (var number in intArray)
//         {
//             Console.WriteLine(number);
//         }
//     }

//     // 可选参数和命名参数
//     static void OptionalParameters(int first, int second = 10, int third = 20)
//     {
//         Console.WriteLine("first = {0}, second = {1}, third = {2}", first, second, third);
//     }
//     static void Test()
//     {
//         OptionalParameters(1, third: 30);
//         AnyNumberInts();
//         AnyNumberInts(1, 2, 3, 4, 5);
//     }
// }