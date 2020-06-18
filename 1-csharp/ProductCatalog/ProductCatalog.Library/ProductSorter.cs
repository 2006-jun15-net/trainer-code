using System.Collections.Generic;

namespace ProductCatalog.Library
{
    public class ProductSorter : ISortingAlgorithm<List<Product>>
    {
        public bool SortInReverse { get; set; } = false;

        public void Sort(List<Product> collection)
        {
            if (SortInReverse)
            {
                // sort
                for (int i = 0; i < collection.Count; i++)
                {
                    // bubble sort
                }
            }
        }
    }
}
