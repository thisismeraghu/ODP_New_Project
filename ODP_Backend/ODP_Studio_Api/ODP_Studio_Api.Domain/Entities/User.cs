using ODP_Studio_Api.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using ODP_Studio_Api.Domain.ValueObjects;
using System.Reflection.Metadata;

namespace ODP_Studio_Api.Domain.Entities
{
    [Table("User", Schema = "ODPUser")]
    public class User
    {
        public int UserID { get; private set; }
        public Credentials Credentials { get; private set; }
        public PersonalInformation PersonalInfo { get; private set; } = null!;
        public ContactInformation ContactInfo { get; private set; } = null!;
        public ModifiedInfo ModifiedInfo { get; private set; }
        private readonly List<UserOrgRole> _userOrgRoles = new();
        public IReadOnlyCollection<UserOrgRole> UserOrgRoles => _userOrgRoles.AsReadOnly();
        public string? ProfilePhoto { get; private set; }
        public bool IsActive { get; private set; }
        public string? RefreshToken { get; private set; }

        protected User() { } // For EF Core

        public User(int userId, Credentials credentials,
                    PersonalInformation personalInfo,
                    ContactInformation contactInfo,
                    ModifiedInfo modifiedInfo)
        {
            UserID = userId;
            Credentials = credentials ?? throw new ArgumentNullException(nameof(credentials));
            PersonalInfo = personalInfo ?? throw new ArgumentNullException(nameof(personalInfo));
            ContactInfo = contactInfo ?? throw new ArgumentNullException(nameof(contactInfo));
            ModifiedInfo = modifiedInfo ?? throw new ArgumentNullException(nameof(modifiedInfo));
            IsActive = true;
        }

        // Behavior methods follow encapsulation and business logic

        public void UpdatePersonalInformation(PersonalInformation personalInformation)
        {
            PersonalInfo = personalInformation ?? throw new ArgumentNullException(nameof(personalInformation));
            UpdateModificationInfo();
        }

        public void UpdateContactInfo(ContactInformation contactInfo)
        {
            ContactInfo = contactInfo ?? throw new ArgumentNullException(nameof(contactInfo));
            UpdateModificationInfo();
        }

        public void UpdateCredentials(Credentials credentials)
        {
            Credentials = credentials ?? throw new ArgumentNullException(nameof(credentials));
            UpdateModificationInfo();
        }

        public void Activate() => IsActive = true;

        public void Deactivate() => IsActive = false;

        public void SetProfilePhoto(string? profilePhoto)
        {
            ProfilePhoto = profilePhoto;
            UpdateModificationInfo();
        }

        public void SetRefreshToken(string? refreshToken)
        {
            RefreshToken = refreshToken;
            UpdateModificationInfo();
        }

        // Add/remove roles managing encapsulation of the collection

        public void AddUserOrgRole(UserOrgRole role)
        {
            if (role == null) throw new ArgumentNullException(nameof(role));
            if (!_userOrgRoles.Contains(role))
            {
                _userOrgRoles.Add(role);
                UpdateModificationInfo();
            }
        }

        public void RemoveUserOrgRole(UserOrgRole role)
        {
            if (role == null) throw new ArgumentNullException(nameof(role));
            if (_userOrgRoles.Remove(role))
            {
                UpdateModificationInfo();
            }
        }

        // Password verification encapsulated in User entity

        public bool VerifyPassword(string password, IPasswordHasher hasher)
        {
            if (hasher == null) throw new ArgumentNullException(nameof(hasher));
            if (password == null) throw new ArgumentNullException(nameof(password));
            return hasher.VerifyHashedPassword(Credentials.Password, password);
        }

        // Private helper to update modification info - domain internal consistency

        private void UpdateModificationInfo()
        {
            // Assuming ModifiedInfo is a value object where you set updated details,
            // e.g. updated timestamps, user identifiers for changes, etc.
            ModifiedInfo = new ModifiedInfo(
                fcb: ModifiedInfo.Fcb,
                lub: ModifiedInfo.Lub /* current user or system identifier who updated */,
                fcd: ModifiedInfo.Fcd,
                lud: DateTime.UtcNow
            );
        }
    }
}
