abstract class BaseClass
{
    public virtual void vf()
    {
        Console.WriteLine("In BaseClass vf");
    }
    public virtual void vf_new()
    {
        Console.WriteLine("In BaseClass vf_new");
    }
    public abstract void vf_abstract();
    public sealed override string ToString()
    {
        Console.WriteLine("In BaseClass vf_sealed");
        return "BaseClass_ToString";
    }
}

internal class DerivedClass : BaseClass
{
    public override void vf()
    {
        Console.WriteLine("In DerivedClass vf");
    }
    public new void vf_new()
    {
        Console.WriteLine("In DerviedClass vf_new");
    }
    public override void vf_abstract()
    {
        Console.WriteLine("In DerivedClass vf_abstract");
    }
}

class Test
{
    static void Main()
    {
        System.Console.WriteLine("Hi");
        DerivedClass o2 = new DerivedClass();
        BaseClass o = o2;
        o.vf();
        o.vf_new();
        o.vf_abstract();
        o.ToString();
        o2.vf();
        o2.vf_new();
        o2.vf_abstract();
        o2.ToString();
    }
}