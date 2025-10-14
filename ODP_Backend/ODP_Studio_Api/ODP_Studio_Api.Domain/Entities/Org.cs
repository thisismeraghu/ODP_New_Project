using ODP_Studio_Api.Domain.Interfaces;
using ODP_Studio_Api.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ODP_Studio_Api.Domain.Entities
{
    public class Org : IHasModifiedInfo
    {
        public Guid OrgId { get; set; }
        public string OrgName { get; set; }
        public Address Address { get; set; }
        public Email ContactEmail { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public ModifiedInfo ModifiedInfo { get; private set; }

        public ICollection<OrphanOrg> OrphanOrgs { get; set; }
        public ICollection<ManagerOrg> ManagerOrgs { get; set; }
    }

}
