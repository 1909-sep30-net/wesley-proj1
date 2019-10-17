using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.Library
{
    public class Merchandise
    {
        /*public string a = "a";
        public int aAmount { get; set; }

        public string b = "b";
        public int bAmount { get; set; }

        public string c = "c";
        public int cAmount { get; set; }

        public bool CheckValidMerchAmount()
        {
            if (aAmount >= 0 && bAmount >= 0 && cAmount >= 0)
                return true;
            else
                return false;
        }*/
        private string Name;

        private decimal Price;

        public string MerchName
        {
            get { return Name; }
            set
            {
                if (value == null || value == "")
                    throw new ArgumentNullException("Item does not exist, Please try again");
                else if (value.Length > 50)
                    throw new ArgumentOutOfRangeException("Item name too long for this system, "
                        + "Have you considered an item with a shorter name?");
                else
                    Name = value;
            }
        }

        public decimal MerchPrice
        {
            get { return Price; }
            set
            {
                Price = value;
            }
        }

        public Merchandise(string n, decimal p)
        {
            Price = p;
            Name = n;
        }

        public override string ToString()
        {
            string str = $"\n\tNAME: {this.Name} \n\tCost:{Math.Round(this.Price, 2)}";
            return str;
        }

        /*public Merchandise(string n)
        {
            Name = n;
        }*/
    }
}
