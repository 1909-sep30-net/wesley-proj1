using System;
using System.Collections.Generic;

namespace EntityFramework.DataAccess.Entities
{
    public partial class Store
    {
        public Store()
        {
            Inventory = new HashSet<Inventory>();
            OrderInfo = new HashSet<OrderInfo>();
        }

        public int Id { get; set; }
        public string Location { get; set; }

        public virtual ICollection<Inventory> Inventory { get; set; }
        public virtual ICollection<OrderInfo> OrderInfo { get; set; }
    }
}
