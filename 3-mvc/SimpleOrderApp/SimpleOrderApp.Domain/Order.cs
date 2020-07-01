using System;

namespace SimpleOrderApp.Domain
{
    public class Order
    {
        public int Quantity { get; }

        public DateTime Placed { get; }

        public Location Location { get; }

        public Order(int quantity, Location location, DateTime? placed = default)
        {
            Quantity = quantity;
            Location = location;
            Placed = DateTime.Now;
            Placed = placed ?? DateTime.Now;
        }
    }
}