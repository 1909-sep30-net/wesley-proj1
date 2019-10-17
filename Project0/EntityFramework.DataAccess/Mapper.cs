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
            Address a;
            a = new Address(store.Street, store.City, store.State, store.Zip);
            int c = store.Id;
            Store k = new Store(a, c);
            foreach(Entities.Inventory i in store.Inventory)
            {
                var merch = MapMerch(i.NameNavigation);
                k.AddNewItem(merch, i.Amount);
            }
            return k;
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

        public static Merchandise MapMerch(Entities.Product merch)
        {
            Merchandise m = new Merchandise(merch.Name, merch.Price);

            return m;
        }

        public static Inventory MapInventory(Entities.Inventory iven)
        {
            Inventory i = new Inventory(iven.Id, iven.Name, iven.Amount, iven.LocationId);
            return i;
        }

        public static Order MapOrder(Entities.OrderInfo OI)
        {
            var store = MapStore(OI.Store);
            var cust = MapCustomer(OI.Customer);
            Order h = new Order(cust, store, OI.Id, OI.OrderTime, OI.Merch);
            foreach (Entities.OrderDetails item in OI.OrderDetails)
            {
                var prod = MapMerch(item.ProductNameNavigation);
                h.details.Add(prod, item.Order.MerchAmount);
            }
            return h;
        }

        public static Entities.OrderInfo MapOrder(Order or)
        {
            return new Entities.OrderInfo
            {
                StoreId = or.OrderSto.StoreID,
                CustomerId = or.OrderCust.CustomerID,
                OrderTime = or.time,
                Merch = or.Prod
            };
        }
        
        public static IEnumerable<Entities.OrderInfo> MapOD(Order OI, int ID)
        {
            var list = new List<Entities.OrderInfo>() { };
            foreach (KeyValuePair<Merchandise, int> item in OI.details)
            {
                list.Add(new Entities.OrderInfo { Merch = item.Key.MerchName, MerchAmount = item.Value, Id = ID });
            }
            return list;
        }
    }
}
