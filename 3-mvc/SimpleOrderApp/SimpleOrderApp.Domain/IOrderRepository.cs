using System.Collections;
using System.Collections.Generic;

namespace SimpleOrderApp.Domain
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll();

        void Create(Order order);
    }
}