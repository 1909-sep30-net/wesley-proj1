﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RandomApp.WebApp.Models
{
    public class MerchandiseMod
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
        public decimal Price { get; set; }

    }
}
