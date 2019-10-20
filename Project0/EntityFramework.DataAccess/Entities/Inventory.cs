using System;
using System.Collections.Generic;

namespace EntityFramework.DataAccess.Entities
{
    public partial class Inventory
    {
        public int Phold { get; set; }
        public int MerchId { get; set; }
        public int LocationId { get; set; }
        public int Stock { get; set; }

        public virtual Store Location { get; set; }
        public virtual Merchandise Merch { get; set; }
    }
}
