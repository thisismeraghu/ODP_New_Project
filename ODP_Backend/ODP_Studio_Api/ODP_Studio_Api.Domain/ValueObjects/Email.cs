using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODP_Studio_Api.Domain.ValueObjects
{
    public class Email
    {
        public string Value { get; private set; }
        protected Email() { }
        public Email(string value) { /* add validation here */ Value = value; }
        // Equality and validation logic
    }
}
