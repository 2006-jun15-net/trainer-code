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
                ProductSorter sorter3 = (ProductSorter)sorterToUse; // this might fail: what if it's really a BuiltinProductSorter value?
                // so it must be explicit. this line will throw an error at runtime because it really is not a ProductSorter.
            }

            // ask the user if it's reverse or not
            // if (true)
            // {
            //     sorterToUse.SortInReverse = true;
            // }

            DisplayProducts(new List<Product> { product }, sorterToUse);
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
