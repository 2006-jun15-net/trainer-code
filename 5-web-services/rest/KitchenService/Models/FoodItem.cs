using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitchenService.Models
{
    public class FoodItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}
