using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RandomApp.WebApp.Models
{
    public class OrderMod
    {
        [Required]
        public int CustomerID { get; set; }
        [Required]
        public int StoreID { get; set; }   
    }
}
