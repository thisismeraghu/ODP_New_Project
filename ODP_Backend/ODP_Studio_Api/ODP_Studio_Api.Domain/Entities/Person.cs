using ODP_Studio_Api.Domain.Interfaces;
using ODP_Studio_Api.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODP_Studio_Api.Domain.Entities
{
    public class Person : IHasModifiedInfo
    {
        public Guid PersonId { get; set; }
        public PersonalInformation PersonalInfo { get; private set; } = null!;
        public string PhoneNumber { get; set; }
        public Address Address { get; set; }
        public bool IsActive { get; set; }
        public ModifiedInfo ModifiedInfo { get; private set; }
    }

}
