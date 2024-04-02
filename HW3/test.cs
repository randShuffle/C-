// using System;
// public class Test
// {
//     static Func<int, int, int> SomeFunc(int one)
//     {
//         int temp = 200;
//         return (two, three) =>
//         {
//             temp += one;
//             return one + two + three + temp;
//         };
    
//     }

//     public static void Main()
//     {
//         Console.WriteLine("返回函数,使用外部变量");
//         Func<int, int, int> Func1 = SomeFunc(500);
//         Func<int, int, int> Func2 = SomeFunc(1000);
//         int r1 = Func1(1,2);
//         int r2 = Func2(1,2);
//         Console.WriteLine("r1:{0} r2: {1}",r1,r2);
//         r1 = Func1(1, 2);
//         r2 = Func2(1,2);
//         Console.WriteLine("r1:{0} r2: {1}0",r1, r2);
//     }

// }





///////////////////////////////////////////
public class Test
{
    delegate void OtherDelegate<T>(T _);
    public static void Main()
    {
        OtherDelegate<Car>carDelegate =(t)=>
        {
            Console.WriteLine(t.GetType().Name);
        };

        carDelegate(new Vehicle());
    }
    
}
