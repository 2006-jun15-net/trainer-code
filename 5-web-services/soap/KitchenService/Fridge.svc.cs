using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using KitchenService.Models;

namespace KitchenService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Fridge" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Fridge.svc or Fridge.svc.cs at the Solution Explorer and start debugging.
    public class Fridge : IFridge
    {
        private static List<FoodItem> s_contents = new List<FoodItem>
        {
            new FoodItem { Id = 1, Name = "expired cheese", ExpirationDate = new DateTime(2020, 6, 14) },
            new FoodItem { Id = 2, Name = "steak", ExpirationDate = new DateTime(2020, 7, 28) },
            new FoodItem { Id = 3, Name = "salmon", ExpirationDate = new DateTime(2020, 7, 28) }
        };

        public ICollection<FoodItem> GetAllContents()
        {
            return s_contents;
        }

        public ICollection<FoodItem> Clean()
        {
            var removed = s_contents.Where(i => i.ExpirationDate < DateTime.Now).ToList();
            s_contents = s_contents.Except(removed).ToList();
            return removed;
        }
    }
}
