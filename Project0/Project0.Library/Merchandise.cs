using System;

namespace Project0.Library
{
    public class Merchandise
    {
        private string Name;

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

        public int MerchID { get; set; }

        public decimal MerchPrice { get; set; }

        public Merchandise(string n, decimal p, int i = 0)
        {
            MerchPrice = p;
            Name = n;
            MerchID = i;
        }

        public override string ToString()
        {
            string str = $"\n\tID: {MerchID} \n\tNAME: {this.Name} \n\tCost:{Math.Round(this.MerchPrice, 2)}";
            return str;
        }
    }
}
