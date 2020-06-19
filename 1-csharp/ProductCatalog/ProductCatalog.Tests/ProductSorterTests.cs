using System;
using System.Collections.Generic;
using ProductCatalog.Library;
using Xunit;

namespace ProductCatalog.Tests
{
    public class ProductSorterTests
    {
        // C# has syntax for "attributes"
        // any class deriving from System.Attribute can be put in brackets
        // before classes, interfaces, properties, fields, methods, method parameters
        // by themselves they don't do anything - but some code looks for those attributes
        //     using "reflection" and does something on that basis

        // if we sort an empty list, it should still be empty.
        [Fact]
        public void EmptyListShouldSortToEmpty()
        {
            // arrange
            //   any necessary setup before the "act". everything in this section is assumed to work correctly.
            //   (if possible/relevant, it should itself get other unit tests.)
            var sorter = new ProductSorter();
            var emptyList = new List<Product>();

            // act
            //    the specific thing (usually 1 method call) that this method is responsible for testing.
            sorter.Sort(emptyList);

            // assert
            //   run checks as much as possible to verify the correct behavior.
            // in xUnit, use Assert static class.
            Assert.Empty(emptyList);

            // in case of an unhandled exception, the test is considered failed.
        }

        [Fact] // marks it as a test (otherwise, it would be a helper method)
        public void SortListWithItemsShouldSortByName()
        {
            // arrange
            var sorter = new ProductSorter();
            var product1 = new Product { Name = "A" };
            var product2 = new Product { Name = "B" };
            var list = new List<Product> { product2, product1 };

            // act
            sorter.Sort(list);

            // assert
            Assert.Equal(2, list.Count); // unchanged length (expected first, actual second)
            Assert.Equal(list[0], product1); // in C#, the indexing operator [] isn't just for arrays
            Assert.Equal(list[1], product2);
        }
    }
}
