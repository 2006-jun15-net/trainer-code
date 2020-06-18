using System.Collections.Generic;

namespace ProductCatalog.App
{
    // the point of creating an interface like this is...
    // let's say i have some need in my project to sort data,
    //   but i have several ways to do it, might need to switch between them.

    // interfaces let us decouple code that needs functionality
    // from code that provides functionality.

    // e.g. methods in the Program class might accept a ISortingAlgorithm
    // parameter. i could pass into those methods an instance of any class
    // that implements that interface.
    public interface ISortingAlgorithm<TCollection>
    {
        void Sort(TCollection collection);
    }
}
