using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleOrderApp.Data.Model;
using SimpleOrderApp.Domain;

namespace SimpleOrderApp.Data
{
    public class OrderRepository : IOrderRepository
    {
        private readonly SimpleOrderContext _context;

        public OrderRepository(SimpleOrderContext context)
        {
            _context = context;
        }

        public IEnumerable<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Create(Order order)
        {
            // query the DB for the location
            var locationEntity = _context.Locations.First(l => l.Name == order.Location.Name);

            // map to EF model
            var orderEntity = new OrderEntity
            {
                Quantity = order.Quantity,
                Location = locationEntity
            };
            _context.Orders.Add(orderEntity);

            // push the changes to the DB
            _context.SaveChanges();

            // update the domain model with the new ID
            order.Id = orderEntity.Id;
        }
    }
}
