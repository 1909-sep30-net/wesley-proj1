using System;
using System.Collections.Generic;

namespace EntityFramework.DataAccess.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            OrderInfo = new HashSet<OrderInfo>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<OrderInfo> OrderInfo { get; set; }
    }
}
