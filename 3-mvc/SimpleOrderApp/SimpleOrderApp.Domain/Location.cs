using System;
using System.Collections.Generic;

namespace SimpleOrderApp.Domain
{
    public class Location
    {
        // relies on name for uniqueness only
        public string Name { get; set; }

        public int Stock { get; private set; }

        // might be null if not loaded
        public List<Order> OrderHistory { get; set; }

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