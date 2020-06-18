using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatalog.Library
{
    // inheritance allows one class to automatically have all the methods, fields, properties, etc.
    // of another class. (code reuse)
    // it's also sometimes able to override the methods or properties of the parent class.
    //   - static methods cannot be overridden
    //   - methods (or properties) have to be marked "virtual", otherwise it's not allowed to override them.

    // base class = parent class
    // derived class = child class
    public class LocatedCircle : Circle
    {
        // get-only auto-properties can still be modified during the constructor but not afterwards
        // (just like readonly fields)
        public int X { get; }
        public int Y { get; }

        // every child class constructor needs to call some parent class constructor first.
        // (the default is the zero-parameter one. if there isn't a zero-parameter ctor, that's an error,
        //     there's no default to rely on)

        public LocatedCircle(double diameter, int x, int y) : base(diameter)
        {
            X = x;
            Y = y;
        }

        public double DistanceToLocation(int otherX, int otherY)
        {
            // distance formula
            return Math.Sqrt((otherX - X) * (otherX - X) + (otherY - Y) * (otherY - Y));
        }

        public new double GetArea()
        {
            return 0;
        }

        // C# allows "method hiding"
        // in this case, the parent method is still there, and will be run if accessed by a variable of the parent type.
        // you've got two methods with the same name in the same object.
    }
}
