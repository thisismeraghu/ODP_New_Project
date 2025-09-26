using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODP_Studio_Api.Domain.ValueObjects
{
    public class Credentials : IEquatable<Credentials>
    {
        public string UserName { get; }
        public string Password { get; }
        public string LoginEmail { get; }
        public string LoginPhone { get; }

        public Credentials(string userName, string password, string loginEmail, string loginPhone)
        {
            UserName = userName ?? throw new ArgumentNullException(nameof(userName));
            Password = password ?? throw new ArgumentNullException(nameof(password));
            LoginEmail = loginEmail ?? throw new ArgumentNullException(nameof(loginEmail));
            LoginPhone = loginPhone ?? throw new ArgumentNullException(nameof(loginPhone));
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Credentials);
        }

        public bool Equals(Credentials? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return UserName == other.UserName &&
                   Password == other.Password &&
                   LoginEmail == other.LoginEmail &&
                   LoginPhone == other.LoginPhone;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(UserName, Password, LoginEmail, LoginPhone);
        }

        public static bool operator ==(Credentials? left, Credentials? right)
        {
            if (left is null) return right is null;
            return left.Equals(right);
        }

        public static bool operator !=(Credentials? left, Credentials? right)
        {
            return !(left == right);
        }
    }

}
