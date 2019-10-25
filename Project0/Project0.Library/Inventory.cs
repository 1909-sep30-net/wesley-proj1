using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.Library
{
    public class Inventory
    {
        //return list of inventory
        //public Merchandise merch = new Merchandise();

        private Merchandise mer;

        private int Amount;
        private int StoreID;


        public int StockAmount
        {
            get { return Amount; }
            set
            {
                Amount = value;
            }
        }

        public Merchandise merch { get { return mer; } set { mer = value; } }

        public int Store
        {
            get { return StoreID; }
            set
            {
                StoreID = value;
            }
        }

        public Inventory(int store, int stock = 0)
        {
            Amount = stock;
            StoreID = store;
        }
        
        /*public bool CheckInventory()
        {
            if (merch.CheckValidMerchAmount() == true)
                return true;
            else
                return false;
        }*/
    }
}
