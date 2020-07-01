using System;

namespace SimpleOrderApp.Domain
{
    public class Order
    {
        // will be zero if the order can't been persisted yet
        public int Id { get; set; }

        public int Quantity { get; }

        public DateTime Placed { get; }

        public Location Location { get; }

        public Order(int quantity, Location location, DateTime placed)
        {
            Quantity = quantity;
            Location = location;
            Placed = placed;
        }

        public Order(ShoppingCart cart)
            : this(cart.Quantity, cart.Location, DateTime.Now)
        {
        }
    }
}