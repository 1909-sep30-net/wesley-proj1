using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using lib = Project0.Library;
using System.Linq;

namespace EntityFramework.DataAccess.Repo
{
    public class OrderRep
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
            foreach (Entities.OrderInfo item in info)
            {
                _context.Add(item);
            }
        }

        public IEnumerable<lib.Order> GetOrders()
        {
            IQueryable<Entities.OrderInfo> items = _context.OrderInfo
                .Include(r => r.OrderDetails)
                    .ThenInclude(d => d.ProductNameNavigation);

            return items.Select(Mapper.MapOrder);
        }

        public IEnumerable<lib.Order> GetOrdersByName(string id)
        {
            IQueryable<Entities.OrderInfo> items = _context.OrderInfo
                .Include(r => r.OrderDetails)
                    .ThenInclude(d => d.ProductNameNavigation)
                .Where(r => r.Merch == id);

            return items.Select(Mapper.MapOrder);
        }

        public IEnumerable<lib.Order> GetOrdersByCust(int id)
        {
            IQueryable<Entities.OrderInfo> items = _context.OrderInfo
                .Include(r => r.OrderDetails)
                    .ThenInclude(d => d.ProductNameNavigation)
                .Where(r => r.CustomerId == id);

            return items.Select(Mapper.MapOrder);
        }

        public IEnumerable<lib.Order> GetOrdersByStore(int id)
        {
            IQueryable<Entities.OrderInfo> items = _context.OrderInfo
                .Include(r => r.OrderDetails)
                    .ThenInclude(d => d.ProductNameNavigation)
                .Where(r => r.StoreId == id);

            return items.Select(Mapper.MapOrder);
        }

        public void EndMe()
        {
            _context.SaveChanges();
        }
    }
}
