using System;

namespace ProductCatalog.Library
{
    // a class without an explicitly coded constructor
    // will have a hidden default constructor, with these characteristics:
    //  - public
    //  - takes zero parameters
    //  - does nothing
    //  in other words, it's the same as: "public Circle() {}"

    // every class (without an explicit base class ) has "object" for its base class.

    public class Circle //: IShape
    {
        // fields
        private double _radius = 0;
        private string _color;

        // property
        public double Diameter
        {
            get { return _radius * 2; }
            set { _radius = value / 2; }
        }

        // property
        public double Circumference
        {
            get { return 2 * Math.PI * this._radius; }
        }

        // method
        // "virtual" means - allowing derived classes to override.
        public virtual double GetArea()
        {
            return Math.PI * _radius * _radius;
        }

        // property
        // public bool IsSymmetrical { get { return true; } }
        public bool IsSymmetrical => true; // equivalent to above

        public int NumberOfSides => 1;

        // as part of this constructor, call the other one with these two parameters.
        // effectively, you can either set the color yourself, or let it be default black.
        // constructor
        public Circle(double diameter) : this(diameter, "black")
        {
        }

        //public Circle() : this(1)
        //{ }

        // constructor
        public Circle(double diameter, string color)
        {
            Diameter = diameter;
            _color = color;
        }

        // public static MakeCircleFromCircumference(double circum)

        public override string ToString()
        {
            return $"{_color} circle with diameter {Diameter}";
        }
    }
}
