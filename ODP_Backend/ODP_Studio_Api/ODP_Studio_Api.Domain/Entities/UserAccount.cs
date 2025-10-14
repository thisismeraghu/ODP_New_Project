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
    //[Table("UserAccount", Schema = "UserAuth")]
    public class UserAccount : IHasModifiedInfo
    {
        public Guid UserAccountId { get; set; }
        public string Username { get; set; }
        public Email Email { get; set; }
        public UserCredentials Credentials { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool IsActive { get; set; }
        public ModifiedInfo ModifiedInfo { get; private set; }
        public DateTime? LastLoginAt { get; set; }
        public virtual UserProfile UserProfile { get; set; }
       
    }


}
