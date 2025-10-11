using ODP_Studio_Api.Domain.Interfaces;
using ODP_Studio_Api.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODP_Studio_Api.Domain.Entities
{
    public class Company : IHasModifiedInfo
    {
        public Guid CompanyId { get; set; }
        public int CompanyKey { get; set; }
        public string CompanyName { get; set; }
        public string Industry { get; set; }
        public Email ContactEmail { get; set; }
        public Address Address { get; set; }
        public bool IsActive { get; set; }
        public ModifiedInfo ModifiedInfo { get; private set; }
    }

}
