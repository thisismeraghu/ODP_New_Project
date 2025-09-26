using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODP_Studio_Api.Domain.ValueObjects
{
    public class ContactInformation : IEquatable<ContactInformation>
    {
        protected ContactInformation() { } // For EF Core

        public string? PhoneNumber { get; }
        public string? Email { get; }

        public ContactInformation(string? phoneNumber, string? email)
        {
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as ContactInformation);
        }

        public bool Equals(ContactInformation? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return PhoneNumber == other.PhoneNumber &&
                   Email == other.Email;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(PhoneNumber, Email);
        }

        public static bool operator ==(ContactInformation? left, ContactInformation? right)
        {
            if (left is null) return right is null;
            return left.Equals(right);
        }

        public static bool operator !=(ContactInformation? left, ContactInformation? right)
        {
            return !(left == right);
        }
    }


}
