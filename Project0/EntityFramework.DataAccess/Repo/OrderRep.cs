using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using lib = Project0.Library;
using System.Linq;
using Project0.Library.Repo;

namespace EntityFramework.DataAccess.Repo
{
    public class OrderRep : IOrderRep
    {
        private readonly Entities.Project0Context _context;

        public OrderRep(Entities.Project0Context dbcontext) =>
            _context = dbcontext ?? throw new ArgumentNullException(nameof(dbcontext));

        public void Order(lib.Order oi)
        {
            if (oi.OrderID != 0)
                Console.WriteLine("Order ID is already set");
            Entities.OrderInfo OI = Mapper.MapOrder(oi);
            _context.Add(OI);
        }

        public void AddOrder(lib.Order oi)
        {
            var info = Mapper.MapOD(oi, oi.OrderID);
            foreach (Entities.OrderDetails item in info)
            {
                _context.Add(item);
            }
        }

        public IEnumerable<lib.Order> GetOrders()
        {
            IQueryable<Entities.OrderInfo> items = _context.OrderInfo
                .Include(r => r.OrderDetails)
                    .ThenInclude(d => d.Merch)
                .Include(r => r.Customer)
                .Include(r => r.Store);

            return items.Select(Mapper.MapOrder);
        }

        /*public IEnumerable<lib.Order> GetOrdersByName(int id)
        {
            IQueryable<Entities.OrderInfo> items = _context.OrderInfo
                .Include(r => r.OrderDetails)
                    .ThenInclude(d => d.Merch)
                .Where(r => r.Id == id);

            return items.Select(Mapper.MapOrder);
        }*/

        public IEnumerable<lib.Order> GetOrdersByCust(int id)
        {
            IQueryable<Entities.OrderInfo> items = _context.OrderInfo
                .Include(r => r.OrderDetails)
                    .ThenInclude(d => d.Merch)
                .Include(od => od.Customer)
                .Include(od => od.Store)
                .Where(r => r.CustomerId == id);

            List<lib.Order> od = items.Select(Mapper.MapOrder).ToList();

            return items.Select(Mapper.MapOrder);
        }

        public IEnumerable<lib.Order> GetOrdersByStore(int id)
        {
            IQueryable<Entities.OrderInfo> items = _context.OrderInfo
                .Include(r => r.OrderDetails)
                    .ThenInclude(d => d.Merch)
                .Include(r => r.Store)
                .Include(r => r.Customer)
                .Where(r => r.StoreId == id);

            return items.Select(Mapper.MapOrder);
        }

        public void EndMe()
        {
            _context.SaveChanges();
        }
    }
}
