using Project0.Library;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework.DataAccess
{
    public class Mapper
    {
        public static Store MapStore(Entities.Store store)
        {
            string a = store.Location;
            int c = store.Id;
            
            Store k = new Store(a, c);
            foreach (Entities.Inventory i in store.Inventory)
            {
                
                var merch = MapMerch(i.Merch);
                k.AddNewItem(merch, i.Stock);
            }
            return k;
        }
        public static Entities.Store MapStore(Store store)
        {
            var p = new List<Entities.Inventory> { };
            foreach (KeyValuePair<Merchandise, int> item in store.iven)
            {
                p.Add(new Entities.Inventory { MerchId = item.Key.MerchID, Stock = item.Value, LocationId = store.StoreID});
            }
            return new Entities.Store
            {
                Id = store.StoreID,
                Inventory = p
            };
        }

        public static Customer MapCustomer(Entities.Customer cust)
        {
            Customer c = new Customer(cust.FirstName, cust.LastName, cust.Id);
            return c;
        }

        public static Entities.Customer MapCustomer(Customer cust)
        {
            return new Entities.Customer
            {
                FirstName = cust.FristName,
                LastName = cust.LsatName,
                //Id = cust.CustomerID
            };
        }

        public static Merchandise MapMerch(Entities.Merchandise merch)
        {
            Merchandise m = new Merchandise(merch.Name, merch.Price, merch.Id);

            return m;
        }

        public static Inventory MapInventory(Entities.Inventory iven)
        {
            Inventory i = new Inventory(iven.LocationId);
            return i;
        }

        public static Entities.Inventory MapInventory(Inventory iven)
        {
            return new Entities.Inventory
            {
                MerchId = iven.merch.MerchID,
                LocationId = iven.Store,
                Stock = iven.StockAmount
            };
        }

        public static Order MapOrder(Entities.OrderInfo OI)
        {
            var store = OI.Store is null ? null : MapStore(OI.Store);
            var cust = MapCustomer(OI.Customer);
            Order h = new Order(cust, store, OI.Id, OI.OrderTime);
            foreach (Entities.OrderDetails item in OI.OrderDetails)
            {
                var prod = MapMerch(item.Merch);
                h.details.Add(prod, item.Stock);
            }
            return h;
        }

        public static Entities.OrderInfo MapOrder(Order or)
        {
            return new Entities.OrderInfo
            {
                StoreId = or.OrderSto.StoreID,
                CustomerId = or.OrderCust.CustomerID,
                OrderTime = or.time
            };
        }

        public static IEnumerable<Entities.OrderDetails> MapOD(Order OI, int ID)
        {
            var list = new List<Entities.OrderDetails>() { };
            foreach (KeyValuePair<Merchandise, int> item in OI.details)
            {
                list.Add(new Entities.OrderDetails { MerchId = item.Key.MerchID, Stock = item.Value, OrderId = ID });
            }
            return list;
        }
    }
}
