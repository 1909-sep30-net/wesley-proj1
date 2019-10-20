using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.Library
{
    public class Merchandise
    {
        private string Name;
        private int ID;
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
        
        public int MerchID
        {
            get { return ID; }
            set
            {
                ID = value;
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

        public Merchandise(string n, decimal p, int i = 0)
        {
            Price = p;
            Name = n;
            ID = i;
        }

        public override string ToString()
        {
            string str = $"\n\tID: {ID} \n\tNAME: {this.Name} \n\tCost:{Math.Round(this.Price, 2)}";
            return str;
        }
    }
}
