using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Project0.Library
{
    public class Store
    {
        //colorado, texas, georgia, arizona, florida

        private int ID;
        private string Location;

        private Dictionary<Merchandise, int/*quantity*/> ive;

        public int StoreID
        {
            get { return ID; }
            set
            {
                ID = value;
            }
        }

        public Dictionary<Merchandise, int> iven { get { return ive; } set { ive = value; } }

        public string Loc
        {
            get { return Location; }
            set
            {
                Location = value;
            }
        }

        public Dictionary<Merchandise,int/*quantity*/> Inven
        {
            get { return iven; }
        }

        public Store(string a, int id)
        {
            Location = a;
            ID = id;
            iven = new Dictionary<Merchandise, int/*quantity*/>() { };
        }

        /*public bool CheckStoreValid()
        {
            if (Address != null && Inventory.merch.aAmount >= 0 && Inventory.merch.bAmount >= 0 && Inventory.merch.cAmount >= 0)
                return true;
            else
                return false;
        }*/

        public bool AddNewItem(Merchandise item, int quantity)
        {
            if (item == null)
                return false;
            bool exist = false;
            foreach (KeyValuePair<Merchandise, int> i in iven)
            {
                if (i.Key == item)
                {
                    exist = true;
                    break;
                }
            }
            if (exist)
            {
                Console.WriteLine("I already got this item in stock, how many you want");
                return false;
            }
            else
            {
                iven.Add(item, quantity);
                return true;
            }
        }
        public bool ItemID(int id)
        {
            foreach (KeyValuePair<Merchandise,int> item in iven)
            {
                if (item.Key.MerchID == id)
                    return true;
            }
            return false;
        }
        public bool ChangeStock(Merchandise merch, int amount)
        {
            int value = 0;
            foreach (KeyValuePair<Merchandise, int> item in iven)
            {
                value = item.Value + amount;
                if (item.Key.MerchID == merch.MerchID)
                {
                    if (item.Value + amount > 0)
                    {
                        iven[item.Key] = value;
                        return true;
                    }
                    else
                    {
                        Console.WriteLine($"I got your item, but I only got {item.Value} left");
                        return false;
                    }
                }
            }
            Console.WriteLine("I dont have that in stock");
            return false;
        }
        public string InventoryToString()
        {
            string str = "";
            foreach (KeyValuePair<Merchandise, int> item in iven)
            {
                str += $"\n{item.Key.ToString()} \n\t\tQuantity: {item.Value}";
            }
            return str;
        }

        public override string ToString()
        {
            return $"\tID : {StoreID} \n\tADDRESS: {Location}";
        }
    }
}
