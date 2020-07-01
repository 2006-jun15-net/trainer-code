﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SimpleOrderApp.Data;
using SimpleOrderApp.Domain;

namespace SimpleOrderApp.App
{
    public class Program
    {
        public static void Main()
        {
            // create dependencies
            var factory = new SimpleOrderContextFactory();
            using var context = factory.CreateDbContext();
            ILocationRepository locationRepo = new LocationRepository(context);
            IOrderRepository orderRepo = new OrderRepository(context);
            var orderService = new OrderService(orderRepo, locationRepo);
            
            // manage UI

            Console.WriteLine("Welcome to my store");

            Console.WriteLine("Select a location:");
            var chosenLocation = PromptForLocation(locationRepo);

            var shoppingCart = PromptForOrder(chosenLocation);

            // TODO: prompt user to confirm

            // TODO: exception handling
            orderService.PlaceOrder(shoppingCart);

            Console.WriteLine("Thank you for shopping");
        }

        public static ShoppingCart PromptForOrder(Location location)
        {
            // loop until successful order placed
            while (true)
            {
                Console.WriteLine("Add quantity to add to cart: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int quantity))
                {
                    try
                    {
                        var cart = new ShoppingCart(location)
                        {
                            Quantity = quantity
                        };

                        return cart;
                    }
                    catch (Exception ex)
                    {
                        // not enough stock or negative number etc.
                        Console.WriteLine($"Error - {ex.Message}");
                        Console.WriteLine("Try again");
                        Console.WriteLine();
                    }
                }
            }
        }

        public static Location PromptForLocation(ILocationRepository locationRepo)
        {
            var locations = locationRepo.GetAll().ToList();

            Console.WriteLine("Locations:");
            Console.WriteLine();
            foreach (Location location in locations)
            {
                Console.WriteLine($"\t{location}");
            }

            Console.WriteLine();
            while (true)
            {
                Console.WriteLine("Choose one: ");
                string input = Console.ReadLine();

                if (locations.FirstOrDefault(l => l.Name == input) is Location location)
                {
                    return location;
                }
                Console.WriteLine("Invalid; try again");
            }
        }
    }
}
