using System;
using System.Collections.Generic;

namespace EntityFramework.DataAccess.Entities
{
    public partial class Inventory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public int LocationId { get; set; }

        public virtual Store Location { get; set; }
        public virtual Product NameNavigation { get; set; }
    }
}
