﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomApp.WebApp.Models
{
    public class EndOrderViewMod
    {
        public int merchID { get; set; }
        public string merchName { get; set; }
        public decimal merchPrice { get; set; }
        public int quantity { get; set; }
        public decimal total { get; set; }
    }
}
