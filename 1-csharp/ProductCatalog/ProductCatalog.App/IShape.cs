namespace ProductCatalog.App
{
    // just as a class specifies requirements for the objects that are instances
    //    of that class,
    // an interface specifies requirements on classes that mark themselves
    //    as implementors of that interface
    public interface IShape
    {
        // there must be such a method on any class
        // that claims to implement the IShape interface
        void Scale(double sizeMultiplier);
    }
}
