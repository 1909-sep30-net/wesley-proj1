
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

        //Added a console message here-Tri
        public bool CheckValidAddress()
        {
            if (Street != null && City != null && State != null && Zip != null)
                return true;
            else
                System.Console.WriteLine("That's not a valid address, try again.");
                return false;
        }
    }
}
