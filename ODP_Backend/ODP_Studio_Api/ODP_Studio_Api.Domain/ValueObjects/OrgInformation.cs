using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODP_Studio_Api.Domain.ValueObjects
{
    public class OrgInformation
    {
        public Address Address { get; set; }
        public Email ContactEmail { get; set; }
    }
}
