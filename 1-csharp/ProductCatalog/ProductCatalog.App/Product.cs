using System;

namespace ProductCatalog.App
{
    // C# supports many paradigms of programming
    // above all, it's an object-oriented language.

    // package related data and behavior together as one unit called an object.
    // the object will have control over those things, the object can enforce
    // any restrictions or rules about its own data or behavior.
    // "encapsulation"

    class Product
    {
        // an "auto-implemented property" or just "auto-property"
        // - it's based on a hidden backing field of type double,
        // but i can modify its implementation later if my needs change.
        private double _price;

        public double Price
        {
            // get { return _price; }
            get => _price; // equivalent to the above
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "price can't be nonpositive.");
                }
                _price = value;
            }
        }

        public string Color { get; set; }

        // the backing field for Name property
        private string _name;

        // "full property" - no hidden field, full control over validation etc.
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public void ApplyDiscount(int percentage)
        {
            double multiplier = 1 - percentage / 100.0;
            Price *= multiplier;
        }
    }
}
