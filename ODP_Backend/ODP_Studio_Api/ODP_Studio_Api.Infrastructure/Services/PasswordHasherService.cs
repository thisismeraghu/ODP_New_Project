using Microsoft.AspNetCore.Identity;
using ODP_Studio_Api.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODP_Studio_Api.Infrastructure.Services
{
    public class PasswordHasherService : IPasswordHasher
    {
        private readonly PasswordHasher<object> _passwordHasher = new PasswordHasher<object>();

        public bool VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            var result = _passwordHasher.VerifyHashedPassword(null, hashedPassword, providedPassword);
            return result == PasswordVerificationResult.Success;
        }

        public string HashPassword(string password)
        {
            return _passwordHasher.HashPassword(null, password);
        }
    }
}
