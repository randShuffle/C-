// using System;
// using System.Security.Authentication;
// public class SomeType
// {
// class SomeNestType
// {
// public void f() { Console.WriteLine("f"); }
// }
// const Int32 SomeConstant = 1000;
// public readonly Int32 SomereadOnlyFiled = 2;
// static Int32 SomeReadWriteFiled = 3;
// static SomeType()
// {
// Console.WriteLine("Static SomeType");
// }
// public SomeType()
// {
// Console.WriteLine("Inst SomeType");
// SomereadOnlyFiled = 100;
// }
// public SomeType(Int32 x) { }
// ~SomeType()
// {
// Console.WriteLine("~SomeType");
// }
// int II
// {
// get; set;
// }
// int F
// {
// get { return SomereadOnlyFiled; }
// }
// public int this[int v]
// {
// get
// {
// int[] bb = { 55, 33, 44 };
// return bb[v];
// }
// }
// public event EventHandler SomeEvent;
// public void f()
// {
// //SomereadOnlyFiled = 1000;
// }
// public override string ToString()
// {
// return "SomeTypeToStringVal";
// }
// static void M1(Object sender, EventArgs e)
// {
// SomeType o = (SomeType)sender;
// Console.WriteLine("M1:{0}", o.SomereadOnlyFiled);
// }
// void M2(Object sender, EventArgs e)
// {
// SomeType o = (SomeType)sender;
// Console.WriteLine("M2:{0}", o.SomereadOnlyFiled);
// }
// void Trigger()
// {
// SomeEvent(this, null);
// }
// static void Main()
// {
// SomeType s = new SomeType();
// Console.WriteLine("Hi");
// SomeNestType o = new SomeNestType();
// o.f();
// Console.WriteLine("ToString {0}", s);
// Console.WriteLine("SomereadOnlyFiled {0}", s.SomereadOnlyFiled);
// Console.WriteLine("SomeReadWriteFiled {0}", SomeReadWriteFiled);
// Console.WriteLine("SomeConstant {0}", SomeConstant);
// s.MyF(300);
// s.II = 9;
// Console.WriteLine("Hi {0} {1}", s.II, s.F);
// Console.WriteLine("{0}, {1}", s[0], s[2]);
// s.SomeEvent += SomeType.M1;
// s.SomeEvent += s.M2;
// s.Trigger();
// }
// }
// public static class SomeExtent
// {
// public static void MyF(this SomeType e, int nn)
// {
// Console.WriteLine("MyF {0} {1}", nn, e.SomereadOnlyFiled);
// }
// }
// // using System;

// // public class SomeType
// // {
// //     static void Main()
// //     {
// //         Console.WriteLine("Static SomeType");
// //         Console.WriteLine("Inst SomeType");
// //         Console.WriteLine("Hi");
// //         Console.WriteLine("f");
// //         Console.WriteLine("ToString SomeTypeToStringVal");
// //         Console.WriteLine("SomereadOnlyFiled 100");
// //         Console.WriteLine("SomeReadWriteFiled 3");
// //         Console.WriteLine("SomeConstant 1000");
// //         Console.WriteLine("MyF 300 100");
// //         Console.WriteLine("Hi 9 100");
// //         Console.WriteLine("55, 44");
// //         Console.WriteLine("M1:100");
// //         Console.WriteLine("M2:100");
// //     }
// // }