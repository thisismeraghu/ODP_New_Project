using ODP_Studio_Api.Domain.Interfaces;
using ODP_Studio_Api.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODP_Studio_Api.Domain.Entities
{
    public class Orphan : IHasModifiedInfo
    {
        public Guid OrphanId { get; set; }
        public PersonalInformation PersonalInfo { get;  set; } = null!;
        public DateTime AdmissionDate { get; set; }
        public string CurrentStatus { get; set; }
        public bool IsActive { get; set; }
        public ModifiedInfo ModifiedInfo { get; set; } = null!;

        public ICollection<OrphanOrg> OrphanOrgs { get; set; }
    }

}
