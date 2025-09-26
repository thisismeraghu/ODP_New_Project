using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODP_Studio_Api.Domain.ValueObjects
{
    public class ModifiedInfo : IEquatable<ModifiedInfo>
    {
        public string? Fcb { get; }
        public string? Lub { get; }
        public DateTime? Fcd { get; }
        public DateTime? Lud { get; }

        protected ModifiedInfo() { } // Parameterless constructor for EF Core
        public ModifiedInfo(string? fcb, string? lub, DateTime? fcd, DateTime? lud)
        {
            Fcb = fcb;
            Lub = lub;
            Fcd = fcd;
            Lud = lud;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as ModifiedInfo);
        }

        public bool Equals(ModifiedInfo? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return Fcb == other.Fcb &&
                   Lub == other.Lub &&
                   Fcd == other.Fcd &&
                   Lud == other.Lud;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Fcb, Lub, Fcd, Lud);
        }

        public static bool operator ==(ModifiedInfo? left, ModifiedInfo? right)
        {
            if (left is null) return right is null;
            return left.Equals(right);
        }

        public static bool operator !=(ModifiedInfo? left, ModifiedInfo? right)
        {
            return !(left == right);
        }
    }

}
