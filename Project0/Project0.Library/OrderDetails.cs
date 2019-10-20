using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.Library
{
    public class OrderDetails
    {
        private Customer Name;
        private Store Merch;
        private int orderId;
        private int stock;

        public Customer customer
        {
            get { return Name; }
            set
            {
                Name = value;
            }
        }

        public Store product
        {
            get { return Merch; }
            set
            {
                Merch = value;
            }
        }

        public int order
        {
            get { return orderId; }
            set
            {
                orderId = value;
            }
        }

        public int OrStock
        {
            get { return stock; }
            set
            {
                stock = value;
            }
        }

        public OrderDetails(Customer a, Store b, int c, int s)
        {
            Name = a;
            Merch = b;
            orderId = c;
            stock = s;
        }
    }
}
