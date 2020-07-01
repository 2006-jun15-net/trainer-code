using System;

namespace SimpleOrderApp.Domain
{
    public class Location
    {
        public int Stock { get; private set; }

        public Location(int initialStock)
        {
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
    }
}