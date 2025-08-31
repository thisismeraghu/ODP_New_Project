using ODP_Studio_Api.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace ODP_Studio_Api.Domain.Entities
{
    [Table("User", Schema = "ODPUser")]
    public class User
    {
        
        public int UserID { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string LoginEmail { get; private set; }
        public string LoginPhone { get; private set; }
        public string? ProfilePhoto { get; private set; }
        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }
        public DateTime? DateOfBirth { get; private set; }
        public int? Age { get; private set; }
        public string? PhoneNum { get; private set; }
        public string? Email { get; private set; }
        public string? Profession { get; private set; }
        public string? Nationality { get; private set; }
        public string? City { get; private set; }
        public bool IsActive { get; private set; }
        public string? fcb { get; private set; }
        public string? lub { get; private set; }
        public DateTime? fcd { get; private set; }
        public DateTime? lud { get; private set; }
        public int? GenderId { get; private set; }
        public string? RefreshToken { get; private set; }

        //Password verification logic(hash comparison)
        public bool VerifyPassword(string password, IPasswordHasher hasher)
        {
            return hasher.VerifyHashedPassword(Password, password);
        }
    }
}
