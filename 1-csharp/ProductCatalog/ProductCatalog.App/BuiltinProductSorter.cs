using System.Collections.Generic;

namespace ProductCatalog.App
{
    public class BuiltinProductSorter : ISortingAlgorithm<List<Product>>
    {
        public void Sort(List<Product> collection)
        {
            collection.Sort();
        }
    }
}
