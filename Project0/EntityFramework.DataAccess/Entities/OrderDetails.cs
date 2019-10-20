using System;
using System.Collections.Generic;

namespace EntityFramework.DataAccess.Entities
{
    public partial class OrderDetails
    {
        public int Phold { get; set; }
        public int OrderId { get; set; }
        public int MerchId { get; set; }
        public int Stock { get; set; }

        public virtual Merchandise Merch { get; set; }
        public virtual OrderInfo Order { get; set; }
    }
}
