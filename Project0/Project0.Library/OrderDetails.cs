
namespace Project0.Library
{
    public class OrderDetails
    {
        public Customer customer { get; set; }

        public Store product { get; set; }

        public int order { get; set; }

        public int OrStock { get; set; }

        //Need to have meaningful parameter names
        public OrderDetails(Customer a, Store b, int c, int s)
        {
            customer = a;
            product = b;
            order = c;
            OrStock = s;
        }
    }
}
