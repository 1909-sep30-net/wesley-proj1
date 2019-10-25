using System.Collections.Generic;

namespace Project0.Library.Repo
{
    public interface ICustomerRep
    {
        public IEnumerable<Customer> GetCustomers(string fname = null, string lname = null, int cusid = -1);

        public void AddCust(Customer c);

        public void why();
    }
}
