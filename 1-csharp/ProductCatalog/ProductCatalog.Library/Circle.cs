using System;

namespace ProductCatalog.Library
{
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

        // constructor
        public Circle(double diameter, string color)
        {
            Diameter = diameter;
            _color = color;
        }

        // public static MakeCircleFromCircumference(double circum)
    }
}
