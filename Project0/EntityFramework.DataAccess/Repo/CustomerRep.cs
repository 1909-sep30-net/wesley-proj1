using System;
using System.Collections.Generic;
using System.Text;
using lib = Project0.Library;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Project0.Library.Repo;

namespace EntityFramework.DataAccess.Repo
{
    public class CustomerRep : ICustomerRep
    {
        private readonly Entities.Project0Context _context;

        public CustomerRep(Entities.Project0Context dbContext) =>
            _context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        public IEnumerable<lib.Customer> GetCustomers(string fname = null, string lname = null, int cusid = -1)
        {
            IQueryable<Entities.Customer> person = _context.Customer
                .Include(c => c.OrderInfo);

            if (fname != null)
                person = person.Where(c => c.FirstName.Contains(fname));
            if (lname != null)
                person = person.Where(c => c.LastName.Contains(lname));

            if (cusid != -1)
                person = person.Where(c => c.Id == cusid);
            return person.Select(Mapper.MapCustomer);
        }

        public void AddCust(lib.Customer c)
        {
            if (c.CustomerID != 0)
                Console.WriteLine("Customer ID will be ignored");
            Entities.Customer a = Mapper.MapCustomer(c);
            a.Id = 0;
            _context.Add(a);
        }

        public void why()
        {
            _context.SaveChanges();
        }
    }
}
