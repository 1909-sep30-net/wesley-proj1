using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.Library.Repo
{
    public interface IOrderRep
    {
        public void Order(Order oi);

        public void AddOrder(Order oi);

        public IEnumerable<Order> GetOrders();

        public IEnumerable<Order> GetOrdersByCust(int id);

        public IEnumerable<Order> GetOrdersByStore(int id);

        public void EndMe();
    }
}
