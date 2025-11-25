using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODP_Studio_Api.Domain.ValueObjects
{
    public class Address
    {
        public string Value { get; set; }
        public Address() { }
        public Address(string value) { Value = value; }
        //Equality and other address properties as needed

        //public string address { get; set; }
    }
}
