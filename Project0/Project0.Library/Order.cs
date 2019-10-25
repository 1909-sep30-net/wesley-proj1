using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Project0.Library
{
    public class Order
    {
        private Customer cust;
        private Store sto;
        private int id;
        private DateTime orderTime;

        private Dictionary<Merchandise, int> detail;

        public Customer OrderCust
        {
            get { return cust; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("I require a real customer");
                else
                    cust = value;
            }
        }

        public Dictionary<Merchandise, int> details { get { return detail; } set { detail = value; } }

        public Store OrderSto
        {
            get { return sto; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("I need a real store");
                else
                    sto = value;
            }
        }

        public int OrderID
        {
            get { return id; }
            set
            {
                id = value;
            }
        }

        public DateTime time
        {
            get { return orderTime; }
            set
            {
                orderTime = value;
            }
        }
        
        public Order(Customer a, Store b, int c)
        {
            cust = a;
            sto = b;
            id = c;
            details = new Dictionary<Merchandise, int>() { };
            orderTime = DateTime.Now;
        }
        public Order(Customer a, Store b, int c, DateTime DT)
        {
            cust = a;
            sto = b;
            id = c;
            details = new Dictionary<Merchandise, int>() { };
            orderTime = DT;
        }

        public bool AdjustQuantity(Merchandise merch, int quantity)
        {
            foreach (KeyValuePair<Merchandise, int> item in details)
            {
                if (item.Key.MerchID == merch.MerchID)
                {
                    if (item.Value + quantity >= 0)
                    {
                        details[item.Key] = item.Value + quantity;
                        return true;
                    }
                    else
                    {
                        Console.WriteLine($"Product found, but only {item.Value} in order. You tried to take {-1 * quantity} amount. Please try again.");
                        return false;
                    }
                }
            }
            //when item is not found in inventory
            Console.WriteLine("Product not found in this Store's inventory.");
            return false;
        }

        public decimal CalcPriceOfOrder()
        {
            decimal total = 0m;
            foreach (KeyValuePair<Merchandise, int> item in details)
            {
                total += item.Key.MerchPrice * item.Value;
            }
            return Math.Round(total, 2);
        }

        /// <summary>
        /// Calculated the number of items in the order.
        /// </summary>
        /// <returns>The number of items in the order</returns>
        public int CalcNumInOrder()
        {
            int result = 0;
            foreach (KeyValuePair<Merchandise, int> item in details)
            {
                result += item.Value;
            }
            return result;
        }

        public string OrderToString()
        {
            string str = "";
            foreach (KeyValuePair<Merchandise, int> item in details)
            {
                var prod = item.Key;
                str += $"\n{prod.ToString()} \n\t\tQuantity: {item.Value}";
            }
            return str;
        }

        public override string ToString()
        {
            return $"\nOrder ID: {this.id} \n\tCustomer ID: {this.cust.CustomerID}\tCustomer Name: {this.cust.FullName}" +
                $"\n\tLocation ID: {this.OrderSto.StoreID}" +
                $"\n\tTimestamp: {this.orderTime}\n\tNumber of Items: {this.CalcNumInOrder()}" +
                $"\n\tTotal Cost: {this.CalcPriceOfOrder()}";
        }
    }
}
