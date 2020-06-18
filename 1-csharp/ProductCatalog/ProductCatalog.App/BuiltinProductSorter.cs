using System.Collections.Generic;
using ProductCatalog.Library;

namespace ProductCatalog.App
{
    // on non-nested types (e.g. a class out here like this) (e.g. class, interface, structs, enums, etc.)
    // only two access levels are possible: public, internal (default).
    //   - public means unrestricted
    //   - internal means only accessible within the project (aka assembly)

    // on members (e.g. methods, properties, fields, nested classes, etc.) 6 access levels are possible
    // the most common four are:
    //   - public
    //   - internal
    //   - protected means only accessible to the containing class or any of its child classes (even in a different project)
    //   - private means only accessible within the containing type (for implementation details within a class)

    class BuiltinProductSorter : ISortingAlgorithm<List<Product>>
    {
        public void Sort(List<Product> collection)
        {
            collection.Sort();
        }
    }
}
