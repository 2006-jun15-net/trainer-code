using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleOrderApp.Data
{
    public class OrderEntity
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public LocationEntity Location { get; set; } // navigation property
        // i don't even need to put a foreign key property here if i don't need it
    }
}
