using ODP_Studio_Api.Domain.Interfaces;
using ODP_Studio_Api.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODP_Studio_Api.Domain.Entities
{
    public class Manager : IHasModifiedInfo
    {
        public Guid ManagerId { get; set; }
        public PersonalInformation PersonalInfo { get; private set; } = null!;
        public Guid CompanyId { get; set; }
        public string Designation { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public ModifiedInfo ModifiedInfo { get; private set; }
        public virtual Company Company { get; set; }
        public ICollection<ManagerOrg> ManagerOrgs { get; set; }
    }

}
