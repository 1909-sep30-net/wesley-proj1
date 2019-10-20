using System;
using System.Collections.Generic;

namespace EntityFramework.DataAccess.Entities
{
    public partial class Merchandise
    {
        public Merchandise()
        {
            Inventory = new HashSet<Inventory>();
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Inventory> Inventory { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
