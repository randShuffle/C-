// using System;
// namespace test_delegate
// {
//     public delegate void GreetingDelegate(string name);

//     public interface lGreeting
//     {
//         void GreetingPeople(string name);
//     }

//     public class EnglishGreeting_cls : lGreeting
//     {
//         public void GreetingPeople(string name)
//         {
//             Console.WriteLine("Morning: "+ name);
//         }

//     }

//     public class ChineseGreeting_cls :lGreeting
//     {
//         public void GreetingPeople(string name)
//         {
//             Console.WriteLine("早上好: "+ name);
//         }

//     }

//     public class Program
//     {
//         static void EnglishGreeting(string name)
//         {
//             Console.WriteLine("Morning: "+ name);
//         }

//         static void ChineseGreeting(string name)
//         {
//             Console.WriteLine("早上好: "+ name);
//         }
//         static void GreetPeople(string name, GreetingDelegate fn)
//         {
//             fn(name);
//         }
//         public static void Main()
//         {
//             Console.WriteLine("test begin");
//             TestInterface();
//             TestSwitch();
//             TestDelegate();
//             Console.WriteLine("test end");
//         }

//         static void GreetPeopleWithInterface(string name, lGreeting makegreeting)
//         {
//             makegreeting.GreetingPeople(name);
//         }
//         static void TestInterface()
//         {
//             Console.WriteLine("test for interface");
//             GreetPeopleWithInterface("Fred", new EnglishGreeting_cls());
//             GreetPeopleWithInterface("Fred", new ChineseGreeting_cls());
        
//         }


//         static void TestSwitch()
//         {
//             Console.WriteLine("test for switch");
//             GreetPeopleWithSwitch("Fred", 1);
//             GreetPeopleWithSwitch("Fred", 2);
//             GreetPeopleWithSwitch("Fred", 3);
//         }
//         static void GreetPeopleWithSwitch(string name, int opt)
//         {
//             switch (opt)
//             {
//                 case 1:
//                     Console.WriteLine("Morning: "+ name); break;
//                 case 2:
//                     Console.WriteLine("早上好: "+ name); break;
//                 default:
//                     Console.WriteLine("opt is not 1 or 2"); break;
//             }
        
//         }

//         static void TestDelegate()
//         {
//             Console.WriteLine("test for delegate");
//             GreetingDelegate d;
//             d = EnglishGreeting;
//             d += ChineseGreeting;
//             GreetPeople("Fred", d);
//         }
        

//     }

// };

