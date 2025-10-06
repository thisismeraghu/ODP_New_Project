using ODP_Studio_Api.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ODP_Studio_Api.Domain.Entities
{
    [Table("UserOrgRole", Schema = "ODPUser")]
    public class UserOrgRole
    {
        public int UserOrgRoleID { get; set; }
        public int UserID { get; set; }
        public int OrgID { get; set; }
        public int RoleTypeID { get; set; }
        public User User { get; set; }
        public Role RoleType { get; set; }
        public Org Org { get; set; }
        public bool IsActive { get; set; }
        public ModifiedInfo ModifiedInfo { get; private set; }
    }
}
