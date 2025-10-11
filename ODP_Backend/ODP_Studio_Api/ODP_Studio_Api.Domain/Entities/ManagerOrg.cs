using ODP_Studio_Api.Domain.Interfaces;
using ODP_Studio_Api.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODP_Studio_Api.Domain.Entities
{
    public class ManagerOrg : IHasModifiedInfo
    {
        public Guid ManagerOrgId { get; set; }
        public int ManagerOrgKey { get; set; }
        public Guid ManagerId { get; set; }
        public Guid OrgId { get; set; }
        public DateTime AssociationStartDate { get; set; }
        public DateTime? AssociationEndDate { get; set; }
        public bool IsActive { get; set; }
        public ModifiedInfo ModifiedInfo { get; private set; }
        public virtual Org Org { get; set; }

        public virtual Manager Manager { get; set; }
    }
}
