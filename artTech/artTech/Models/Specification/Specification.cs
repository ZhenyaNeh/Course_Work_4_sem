using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace artTech.Models.Specification
{
    public class Specification
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public Specification() { }

        public Specification(string name, string value) 
        { 
            Name = name;
            Value = value;
        }
    }
}
