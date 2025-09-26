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
    [Table("ORG", Schema = "ODPOrg")]
    public class Org
    {
        public int OrgID { get; set; }
        public int ServiceTypeID { get; set; }
        public string OrgName { get; set; }
        public string OrgShortName { get; set; }
        public string OrgLogo { get; set; }
        public bool IsUnderGovt { get; set; }
        public DateTime StartedDate { get; set; }
        public ContactInformation ContactInfo { get; private set; } = null!;
        public ModifiedInfo ModifiedInfo { get; private set; }
        public bool IsRegistered { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string url { get; set; }
        public bool IsActive { get; private set; }
       
    }
}
