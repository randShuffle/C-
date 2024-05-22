class Program
{
    static void Main(string[] args)
    {
        using(var context=new CsharpContext())
        {
            var products=context.Products.ToList();
            foreach(var product in products)
            {
                Console.WriteLine($"{product.Name} {product.Price}");
            }
        }

    }

}
