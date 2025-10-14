using ODP_Studio_Api.Domain.Entities;
using ODP_Studio_Api.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODP_Studio_Api.Domain.ModelDTOs
{
    public class UserProfileWithOrgsDto
    {
        public UserProfile UserProfile { get; set; }
        public List<OrphanOrg> OrphanOrgs { get; set; } = new List<OrphanOrg>();
        public List<ManagerOrg> ManagerOrgs { get; set; } = new List<ManagerOrg>();

        public bool VerifyPassword(string password, IPasswordHasher hasher)
        {
            if (hasher == null) throw new ArgumentNullException(nameof(hasher));
            if (password == null) throw new ArgumentNullException(nameof(password));
            var hashPassword = hasher.HashPassword(password);
            return hasher.VerifyHashedPassword(UserProfile.UserAccount.Credentials.PasswordHash, password);
        }
    }
}
