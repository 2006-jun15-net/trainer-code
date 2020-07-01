using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleOrderApp.Domain
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILocationRepository _locationRepository;

        public OrderService(IOrderRepository orderRepository, ILocationRepository locationRepository)
        {
            _orderRepository = orderRepository;
            _locationRepository = locationRepository;
        }

        public Order PlaceOrder(ShoppingCart cart)
        {
            // throws exception if not enough stock
            cart.Location.DecreaseStock(cart.Quantity);

            var order = new Order(cart);

            // TODO: implement unit of work pattern
            // so these two operations can be a transaction together
            // (as-is... it's calling SaveChanges twice)
            _orderRepository.Create(order);
            _locationRepository.Update(cart.Location);

            return order;
        }
    }
}
