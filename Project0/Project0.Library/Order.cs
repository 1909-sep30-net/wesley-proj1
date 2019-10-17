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
        private string merch;
        private DateTime orderTime;

        public Dictionary<Merchandise, int> details;

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

        public string Prod
        {
            get { return merch; }   
            set
            {
                merch = value;
            }
        }

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
            merch = null;
            details = new Dictionary<Merchandise, int>() { };
            orderTime = DateTime.Now;
        }
        public Order(Customer a, Store b, int c, DateTime DT, string m)
        {
            cust = a;
            sto = b;
            id = c;
            merch = m;
            details = new Dictionary<Merchandise, int>() { };
            orderTime = DT;
        }

        public bool AdjustQuantity(Merchandise merch, int quantity)
        {
            foreach (KeyValuePair<Merchandise, int> item in details)
            {
                if (item.Key.MerchName == merch.MerchName)
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
        /// Calculated the number of items in the basket.
        /// </summary>
        /// <returns>The number of items in the basket</returns>
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

        //private list<string> orders = new list<string>();
        //public void ordernumber()
        //{

        //}
        //public void add(string item)
        //{
        //    orders.add(item);
        //}
        //public void remove(string item)
        //{
        //    orders.remove(item);
        //}

        //Information about the order
        /*public Store Store {get; set;}
        public Customer Customer { get; set;}
        public double OrderTime { get; set; }
        public Merchandise m { get; set; }


        public Order(Customer cust, Store sto, double time, Merchandise n)
        {
            Customer = cust;
            Store = sto;
            OrderTime = time;
            m = n;
        }*/

        /*private int ID, custID, StoID, amount;
        private decimal price;
        private string merch;
        private DateTime ti;

        public int order
        {
            get { return ID; }
            set
            {
                ID = value;
            }
        }
        public int customer
        {
            get { return custID; }
            set
            {
                custID = value;
            }
        }
        public int store
        {
            get { return StoID; }
            set
            {
                StoID = value;
            }
        }
        public int ProdAmount
        {
            get { return amount; }
            set
            {
                if (amount < 0)
                    throw new ArgumentOutOfRangeException("Please do not go below 0");
                else
                    amount = value;
            }
        }
        public decimal cost
        {
            get { return price; }
            set
            {
                price = value;
            }
        }
        public string name
        {
            get { return merch; }
            set
            {
                if (value == null || value == "")
                    throw new ArgumentNullException("I need an actual name for a product");
                else if (value.Length > 50)
                    throw new ArgumentOutOfRangeException("The name you just gave is too long");
                else
                    merch = value;
            }
        }
        public DateTime t
        {
            get { return ti; }
            set
            {
                ti = value;
            }
        }

        public Order(int a, int b, int c, int d, decimal x, string y, DateTime z)
        {
            ID = a;
            custID = b;
            StoID = c;
            amount = d;
            price = x;
            merch = y;
            ti = z;
        }*/

        //check order address and validity of order
        /* public Address OrderStoreAddress()
         {
             Console.WriteLine("Store's Address is: " + Store.GetStoreAddress());
             return Store.GetStoreAddress();
         }

         public bool IsOrderValid()
         {
             if (Customer != null && Store != null && m != null && OrderTime >= 0)
             {
                 return true;
             }
             else
                 return false;
         }*/
    }
}
