using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KitchenClient.FridgeService;

namespace KitchenClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Nick's fridge");

            // generated client class, object-oriented representation of the SOAP service (HTTP etc is encapsulated)
            using (var client = new FridgeClient())
            {
                while (true)
                {
                    Console.WriteLine("Press 1 to get all items, 2 to clean the fridge, 3 to exit");

                    char input = Console.ReadKey().KeyChar;
                    Console.WriteLine();

                    switch (input)
                    {
                        case '1':
                            FoodItem[] items = client.GetAllItems();

                            foreach (var item in items)
                            {
                                Console.WriteLine($"{item.Name} ({item.Id}), expires {item.ExpirationDate.Date}");
                            }
                            Console.WriteLine();
                            break;
                        case '2':
                            FoodItem[] removedItems = client.Clean();

                            foreach (var item in removedItems)
                            {
                                Console.WriteLine($"{item.Name} ({item.Id}), expires {item.ExpirationDate.Date}");
                            }
                            Console.WriteLine();
                            break;
                        case '3':
                            return;
                        default:
                            Console.WriteLine("Error");
                            break;
                    }
                }
            }
        }
    }
}
