using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODP_Studio_Api.Domain.ValueObjects
{
    public class PersonalInformation : IEquatable<PersonalInformation>
    {
        protected PersonalInformation() { } // For EF Core

        public string? FirstName { get; }
        public string? LastName { get; }
        public DateTime? DateOfBirth { get; }
        public int? Age { get; }
        public int? GenderId { get; }
        public string? Nationality { get; }
        public string? Profession { get; }
        public string? City { get; }

        public PersonalInformation(string? firstName, string? lastName,
                                   DateTime? dateOfBirth, int? age, int? genderId,
                                   string? nationality, string? profession, string? city)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Age = age;
            GenderId = genderId;
            Nationality = nationality;
            Profession = profession;
            City = city;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as PersonalInformation);
        }

        public bool Equals(PersonalInformation? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return FirstName == other.FirstName &&
                   LastName == other.LastName &&
                   DateOfBirth == other.DateOfBirth &&
                   Age == other.Age &&
                   GenderId == other.GenderId &&
                   Nationality == other.Nationality &&
                   Profession == other.Profession &&
                   City == other.City;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, LastName, DateOfBirth, Age, GenderId,
                                    Nationality, Profession, City);
        }

        public static bool operator ==(PersonalInformation? left, PersonalInformation? right)
        {
            if (left is null) return right is null;
            return left.Equals(right);
        }

        public static bool operator !=(PersonalInformation? left, PersonalInformation? right)
        {
            return !(left == right);
        }
    }


}
