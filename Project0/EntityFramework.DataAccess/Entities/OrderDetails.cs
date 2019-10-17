using System;
using System.Collections.Generic;

namespace EntityFramework.DataAccess.Entities
{
    public partial class OrderDetails
    {
        public string Name { get; set; }
        public int OrderId { get; set; }
        public string ProductName { get; set; }

        public virtual OrderInfo Order { get; set; }
        public virtual Product ProductNameNavigation { get; set; }
    }
}
