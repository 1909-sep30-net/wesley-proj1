using System;
using System.Collections.Generic;
using System.Text;

namespace demo.DataAccess
{
    public class random
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }

        public ICollection<randomtypejoin> a;
    }
}
