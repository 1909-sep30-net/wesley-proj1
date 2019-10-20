using System;
using System.Collections.Generic;
using System.Text;

namespace demo.DataAccess
{
    public class randomtype
    {
        public int id { get; set; }
        public string name { get; set; }

        public ICollection<randomtypejoin> randomtypejoins;
    }
}
