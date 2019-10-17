using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.Library
{
    public class Address
    {
        //street
        public string Street { get; set; }

        //city

        public string City { get; set; }

        //state

        public string State { get; set; }

        //zip code

        public string Zip { get; set; }

        public Address(string str, string cit, string st, string z)
        {
            Street = str;
            City = cit;
            State = st;
            Zip = z;
        }

        public bool CheckValidAddress()
        {
            if (Street != null && City != null && State != null && Zip != null)
                return true;
            else
                return false;
        }
    }
}
