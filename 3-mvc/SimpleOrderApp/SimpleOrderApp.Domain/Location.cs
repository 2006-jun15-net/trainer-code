using System;

namespace SimpleOrderApp.Domain
{
    public class Location
    {
        public string Name { get; set; }

        public int Stock { get; private set; }

        public Location(string name, int initialStock)
        {
            Name = name;
            Stock = initialStock;
        }

        public void DecreaseStock(int amount)
        {
            if (amount < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(amount));
            }
            if (amount > Stock)
            {
                throw new InvalidOperationException("not enough stock");
            }
            Stock -= amount;
        }

        public override string ToString()
        {
            return $"{Name} ({Stock} in stock)";
        }
    }
}