using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODP_Studio_Api.Domain.ValueObjects
{
    public class UserCredentials
    {
        public string PasswordHash { get; private set; }
        public string PasswordSalt { get; private set; }
        protected UserCredentials() { }
        public UserCredentials(string hash, string salt) { PasswordHash = hash; PasswordSalt = salt; }
    }
}
