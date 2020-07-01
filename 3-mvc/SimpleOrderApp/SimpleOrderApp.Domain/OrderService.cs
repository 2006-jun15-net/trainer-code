using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleOrderApp.Domain
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Order PlaceOrder(ShoppingCart cart)
        {
            // throws exception if not enough stock
            cart.Location.DecreaseStock(cart.Quantity);

            var order = new Order(cart.Quantity, cart.Location);

            _orderRepository.Create(order);

            return order;
        }
    }
}
