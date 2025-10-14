using ODP_Studio_Api.Domain.Interfaces;
using ODP_Studio_Api.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODP_Studio_Api.Domain.Entities
{
   // [Table("UserProfile", Schema = "UserAuth")]
    public class UserProfile : IHasModifiedInfo
    {
        public Guid UserProfileId { get; set; }
        public Guid UserAccountId { get; set; } // FK
        public string UserType { get; set; } // "Orphan", "Manager", "Person"
        public Guid EntityId { get; set; }
        public Guid RoleId { get; set; }
        public bool IsActive { get; set; }
        public ModifiedInfo ModifiedInfo { get; private set; }
        public virtual UserAccount UserAccount { get; set; }
        public virtual Role Role { get; set; }
        //public ICollection<OrphanOrg>? OrphanOrgs { get; set; }
        //public ICollection<ManagerOrg>? ManagerOrgs { get; set; }

        public bool VerifyPassword(string password, IPasswordHasher hasher)
        {
            if (hasher == null) throw new ArgumentNullException(nameof(hasher));
            if (password == null) throw new ArgumentNullException(nameof(password));
            return hasher.VerifyHashedPassword(UserAccount.Credentials.PasswordHash, password);
        }
    }

}
