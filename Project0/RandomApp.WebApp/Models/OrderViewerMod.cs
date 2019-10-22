using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomApp.WebApp.Models
{
    public class OrderViewerMod
    {
        public int OrderID { get; set; }
        public int CustID { get; set; }
        public string Name { get; set; }
        public int StoID { get; set; }
        public string StoLoc { get; set; }
        public DateTime time { get; set; }
        public decimal Cost { get; set; }
    }
}
