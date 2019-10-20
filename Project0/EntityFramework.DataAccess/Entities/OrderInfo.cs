using System;
using System.Collections.Generic;

namespace EntityFramework.DataAccess.Entities
{
    public partial class OrderInfo
    {
        public OrderInfo()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int StoreId { get; set; }
        public DateTime OrderTime { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Store Store { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
