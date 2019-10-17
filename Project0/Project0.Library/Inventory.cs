using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.Library
{
    public class Inventory
    {
        //return list of inventory
        //public Merchandise merch = new Merchandise();

        public Merchandise merch;

        private int ID;
        private string Name;
        private int Amount;
        private int StoreID;

        public int InventoryID
        {
            get { return ID; }
            set
            {
                ID = value;
            }
        }

        public string MerchName
        {
            get { return Name; }
            set
            {
                Name = value;
            }
        }

        public int StockAmount
        {
            get { return Amount; }
            set
            {
                Amount = value;
            }
        }

        public int Store
        {
            get { return StoreID; }
            set
            {
                StoreID = value;
            }
        }

        /*public Inventory(List<Merchandise> i)
        {
            inventory = i;
        }*/

        /*public void inventoryAmount(List<Merchandise> stock)
        {
            // return what is in stock
            foreach (Merchandise item in stock)
                Console.WriteLine("The items in stock are: " + item);
        }*/
        public Inventory(int id, string merch, int stock, int store)
        {
            ID = id;
            Name = merch;
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
