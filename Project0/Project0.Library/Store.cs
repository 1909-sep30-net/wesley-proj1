using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.Library
{
    public class Store
    {
        //colorado, texas, georgia, arizona, florida

        private int ID;
        private string street, city, state, zip;

        public Dictionary<Merchandise, int> iven;

        public int StoreID
        {
            get { return ID; }
            set
            {
                ID = value;
            }
        }

        public string st
        {
            get { return street; }
            set
            {
                street = value;
            }
        }

        public string cit
        {
            get { return city; }
            set
            {
                city = value;
            }
        }

        public string sta
        {
            get { return state; }
            set
            {
                state = value;
            }
        }

        public string z
        {
            get { return zip; }
            set
            {
                zip = value;
            }
        }

        public Dictionary<Merchandise,int> Inven
        {
            get { return iven; }
        }

        public Store(Address a, int id /*Inventory i*/)
        {
            street = a.Street;
            city = a.City;
            state = a.State;
            zip = a.Zip;
            ID = id;
            iven = new Dictionary<Merchandise, int>() { };
            //ivenID = i.InventoryID;
        }

        /*public bool CheckStoreValid()
        {
            if (Address != null && Inventory.merch.aAmount >= 0 && Inventory.merch.bAmount >= 0 && Inventory.merch.cAmount >= 0)
                return true;
            else
                return false;
        }*/

        /*public Address GetStoreAddress()
        {
            return Address;
        }*/

        public bool AddNewItem(Merchandise item, int quantity)
        {
            if (item == null)
                return false;
            bool exist = false;
            foreach(KeyValuePair<Merchandise,int> i in iven)
            {
                if(i.Key == item)
                {
                    exist = true;
                    break;
                }
            }
            if(exist)
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
                if (item.Value == id)
                    return true;
            }
            return false;
        }
        public bool ChangeStock(Merchandise merch, int amount)
        {
            foreach (KeyValuePair<Merchandise,int> item in iven)
            {
                if(item.Key == merch)
                {
                    if(item.Value + amount > 0)
                    {
                        iven[merch] = item.Value + amount;
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
            return $"\tID : {StoreID} \n\tADDRESS: {st} " + $" {cit}" + $" {sta}" + $" {z}";
        }
    }
}
