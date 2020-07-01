using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleOrderApp.Domain
{
    public class ShoppingCart
    {
        private int _quantity = 0;

        public int Quantity
        {
            get => _quantity;
            set
            {
                if (value > Location.Stock)
                {
                    throw new ArgumentException(nameof(value), "not enough stock");
                }
                _quantity = value;
            }
        }

        public Location Location { get; }

        public ShoppingCart(Location location)
        {
            Location = location ?? throw new ArgumentNullException(nameof(location));
        }

        public void EmptyCart()
        {
            Quantity = 0;
        }
    }
}
