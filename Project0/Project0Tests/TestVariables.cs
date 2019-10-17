using Project0.Library;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project0Tests
{
    class TestVariables
    {
        public static Address tAddress = new Address("123 Sesame St", "abc", "ab", "12345");

        //public static Customer tCustomer = new Customer("Bob", "Hope");

       /* public static Inventory tInventory = new Inventory()
        {
            merch = new Merchandise()
            {
                aAmount = 3,
                bAmount = 4,
                cAmount = 2
            }

        };

        public static Inventory tInventory2 = new Inventory()
        {
            merch = new Merchandise()
            {
                aAmount = -1,
                bAmount = -3,
                cAmount = -5
            }
        };


        public static Merchandise tMerch = new Merchandise()
        {
            aAmount = 3,
            bAmount = 4,
            cAmount = 2
        };*/

       /* public static Store tStore = new Store(tAddress, tInventory);

        public static Order tOrder = new Order(tCustomer, tStore, 3.0, tMerch);*/

        public Address GetAddress()
        {
            return tAddress;
        }

        /*public Customer GetCustomer()
        {
            return tCustomer;
        }*/

        /*public Inventory GetInventory()
        {
            return tInventory;
        }*/

        /*public Inventory GetInventory2()
        {
            return tInventory2;
        }

        public Store GetStore()
        {
            return tStore;
        }

        public Order GetOrder()
        {
            return tOrder;
        }

        public Merchandise GetMerchandise()
        {
            return tMerch;
        }*/
    }
}
