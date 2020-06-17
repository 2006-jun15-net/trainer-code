using System;

namespace ProductCatalog.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = new Circle(4);

            var product = new Product();
            product.Color = "red";
            product.Name = "bicycle";
            product.Price = 200;

            product.ApplyDiscount(8); // 8% off

            Console.WriteLine($"price after discount: ${product.Price}");

            Console.WriteLine("Hello World!");
        }
    }
}
