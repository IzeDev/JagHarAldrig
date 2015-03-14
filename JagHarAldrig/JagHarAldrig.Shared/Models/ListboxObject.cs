using System;
using System.Collections.Generic;
using System.Text;

namespace JagHarAldrig.Models
{
    public class ListboxObject
    {
        public string Value { get; set; }
        public ListboxObject(string value)
        {
            Value = value;
        }
        public override string ToString()
        {
            return Value;
        }
    }
}
