using System;
using System.Collections.Generic;
using ProductCatalog.Library;

namespace ProductCatalog.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = new Circle(4);
            Console.WriteLine(c); // (WriteLine uses ToString to convert objects to strings (as does the + operator))
            Console.WriteLine(c.GetArea());

            LocatedCircle circle2 = new LocatedCircle(3, 0, 0);
            Console.WriteLine(circle2.GetArea()); // prints: 0

            //                                  (implicit) upcast
            DisplayCircles(new List<Circle> { c, circle2 });

            var product = new Product();
            product.Color = "red";
            product.Name = "bicycle";
            product.Price = 200;

            product.ApplyDiscount(8); // 8% off

            Console.WriteLine($"price after discount: ${product.Price}");

            Console.WriteLine("Hello World!");

            ProductSorter sorter1 = new ProductSorter();
            BuiltinProductSorter sorter2 = new BuiltinProductSorter();

            ISortingAlgorithm<List<Product>> sorterToUse;

            // based on some logic, choose which sorter to use
            if (true)
            {
                // the BuiltinProductSorter value
                // is being implicitly casted to ISortingAlgorithm<List<Product>> type.
                sorterToUse = sorter2;

                // this is allowed by the compiler specifically because that class
                // does indeed implement that interface.
                // this is also called "upcasting"

                // downcasting example:
                //ProductSorter sorter3 = (ProductSorter)sorterToUse; // this might fail: what if it's really a BuiltinProductSorter value?
                // so it must be explicit. this line will throw an error at runtime because it really is not a ProductSorter.

                // in VS:   comment with Ctrl+K, Ctrl+C
                // in VS: uncomment with Ctrl+K, Ctrl+U
            }

            // ask the user if it's reverse or not
            // if (true)
            // {
            //     sorterToUse.SortInReverse = true;
            // }

            DisplayProducts(new List<Product> { product }, sorterToUse);
        }

        static void DisplayCircles(List<Circle> circles)
        {
            foreach (Circle circle in circles)
            {
                Console.WriteLine($"{circle}, with area {circle.GetArea()}");
                // when you override a method, it really totally replaces the parent implementation
                // in the object itself, no matter what type variable is looking at that object.
            }
        }

        static void DisplayProducts(List<Product> products, ISortingAlgorithm<List<Product>> sorter)
        {
            sorter.Sort(products);
            // display
            foreach(Product p in products)
            {
                Console.WriteLine(p);
            }
        }
    }
}
