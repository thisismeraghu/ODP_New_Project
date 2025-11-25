using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ODP_Studio_Api.Domain.Entities;
using ODP_Studio_Api.Domain.Interfaces;

namespace ODP_Studio_Api.Infrastructure.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Company> Companies => Set<Company>();

        public DbSet<Manager> Managers => Set<Manager>();
        public DbSet<ManagerOrg> ManagerOrgs => Set<ManagerOrg>();
        public DbSet<Org> Orgs => Set<Org>();
        public DbSet<Orphan> Orphans => Set<Orphan>();
        public DbSet<OrphanOrg> OrphanOrgs => Set<OrphanOrg>();

        public DbSet<Permission> Permissions => Set<Permission>();
        public DbSet<Person> Persons => Set<Person>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<UserAccount> UserAccounts => Set<UserAccount>();
        public DbSet<UserProfile> UserProfiles => Set<UserProfile>();
        public DbSet<RolePermission> RolePermissions => Set<RolePermission>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Company in dbo schema or customize if needed
            ConfigureCompany(builder.Entity<Company>().ToTable("Company", "Company"));

            // Entity schema
            ConfigureManager(builder.Entity<Manager>().ToTable("Manager", "Entity"));
            ConfigureOrphan(builder.Entity<Orphan>().ToTable("Orphan", "Entity"));
            ConfigurePerson(builder.Entity<Person>().ToTable("Person", "Entity"));

            // Org schema
            ConfigureOrg(builder.Entity<Org>().ToTable("Org", "Org"));
            ConfigureManagerOrg(builder.Entity<ManagerOrg>().ToTable("ManagerOrg", "Org"));
            ConfigureOrphanOrg(builder.Entity<OrphanOrg>().ToTable("OrphanOrg", "Org"));

            // UserAuth schema
            ConfigureUserAccount(builder.Entity<UserAccount>().ToTable("UserAccount", "UserAuth"));
            ConfigureUserProfile(builder.Entity<UserProfile>().ToTable("UserProfile", "UserAuth"));

            // UserRole schema
            ConfigurePermission(builder.Entity<Permission>().ToTable("Permission", "UserRole"));
            ConfigureRole(builder.Entity<Role>().ToTable("Role", "UserRole"));
            ConfigureRolePermission(builder.Entity<RolePermission>().ToTable("RolePermission", "UserRole"));
        }

        private void ConfigureCompany(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(c => c.CompanyId);

            builder.Property(c => c.CompanyName).IsRequired().HasMaxLength(200);
            builder.Property(c => c.Industry).HasMaxLength(100);

            builder.OwnsOne(c => c.ContactEmail, email =>
            {
                email.Property(e => e.Value).HasColumnName("ContactEmail").IsRequired();
            });

            builder.OwnsOne(c => c.Address, addr =>
            {
                addr.Property(a => a.Value).HasColumnName("Address");
            });

            ConfigureCommonFields(builder);
        }

        private void ConfigureManager(EntityTypeBuilder<Manager> builder)
        {
            builder.HasKey(m => m.ManagerId);

            builder.OwnsOne(m => m.PersonalInfo, pi =>
            {
                pi.Property(p => p.FirstName).HasColumnName("FirstName").IsRequired().HasMaxLength(100);
                pi.Property(p => p.LastName).HasColumnName("LastName").IsRequired().HasMaxLength(100);
                pi.Property(p => p.DateOfBirth).HasColumnName("DateOfBirth");
                pi.Property(p => p.Gender).HasColumnName("Gender").HasMaxLength(10);
            });

            builder.Property(m => m.Designation).HasMaxLength(100);
            builder.Property(m => m.PhoneNumber).HasMaxLength(20);

            builder.HasOne(m => m.Company)
                .WithMany()
                .HasForeignKey(m => m.CompanyId);

            builder.HasMany(m => m.ManagerOrgs)
                .WithOne(mo => mo.Manager)  // Assuming navigation property added
                .HasForeignKey(mo => mo.ManagerId);

            ConfigureCommonFields(builder);
        }

        private void ConfigureManagerOrg(EntityTypeBuilder<ManagerOrg> builder)
        {
            builder.HasKey(mo => mo.ManagerOrgId);

            builder.Property(mo => mo.AssociationStartDate).IsRequired();
            builder.Property(mo => mo.AssociationEndDate);

            builder.HasOne(mo => mo.Org)
                .WithMany(oo => oo.ManagerOrgs)
                .HasForeignKey(mo => mo.OrgId);

            builder.HasOne(mo => mo.Manager)
                .WithMany(mo => mo.ManagerOrgs)
                .HasForeignKey(mo => mo.ManagerId);

            ConfigureCommonFields(builder);
        }

        private void ConfigureOrg(EntityTypeBuilder<Org> builder)
        {
            builder.HasKey(o => o.OrgId);

            builder.Property(o => o.OrgName).IsRequired().HasMaxLength(200);
            builder.Property(o => o.PhoneNumber).HasMaxLength(20);

            builder.OwnsOne(o => o.OrgInfo, OrgInfo =>
            {
                OrgInfo.OwnsOne( a => a.Address, addr =>
                {
                   addr.Property(a => a.Value).HasColumnName("Address");
                });
            });

            builder.OwnsOne(o => o.OrgInfo, OrgInfo =>
            {
                OrgInfo.OwnsOne( c => c.ContactEmail, email =>
                {
                    email.Property(e => e.Value).HasColumnName("ContactEmail").IsRequired();
                });
            });

            builder.HasMany(o => o.OrphanOrgs)
                .WithOne(oo => oo.Org)
                .HasForeignKey(oo => oo.OrgId);

            builder.HasMany(o => o.ManagerOrgs)
                .WithOne(mo => mo.Org)
                .HasForeignKey(mo => mo.OrgId);

            ConfigureCommonFields(builder);
        }

        private void ConfigureOrphan(EntityTypeBuilder<Orphan> builder)
        {
            builder.HasKey(o => o.OrphanId);
           // builder.HasIndex(o => o.OrphanKey);

            builder.OwnsOne(o => o.PersonalInfo, pi =>
            {
                pi.Property(p => p.FirstName).HasColumnName("FirstName").IsRequired().HasMaxLength(100);
                pi.Property(p => p.LastName).HasColumnName("LastName").IsRequired().HasMaxLength(100);
                pi.Property(p => p.DateOfBirth).HasColumnName("DateOfBirth");
                pi.Property(p => p.Gender).HasColumnName("Gender").HasMaxLength(10);
            });

            builder.Property(o => o.AdmissionDate).IsRequired();
            builder.Property(o => o.CurrentStatus).HasMaxLength(50);

            builder.HasMany(o => o.OrphanOrgs)
                .WithOne(oo => oo.Orphan)
                .HasForeignKey(oo => oo.OrphanId);

            ConfigureCommonFields(builder);
        }

        private void ConfigureOrphanOrg(EntityTypeBuilder<OrphanOrg> builder)
        {
            builder.HasKey(oo => oo.OrphanOrgId);
           // builder.HasIndex(oo => oo.OrphanOrgKey).IsUnique().IsClustered();

            builder.Property(oo => oo.AssociationStartDate).IsRequired();
            builder.Property(oo => oo.AssociationEndDate);

            builder.HasOne(oo => oo.Org)
                .WithMany(oo => oo.OrphanOrgs)
                .HasForeignKey(oo => oo.OrgId);

            builder.HasOne(oo => oo.Orphan)
                .WithMany(oo => oo.OrphanOrgs)
                .HasForeignKey(oo => oo.OrphanId);

            ConfigureCommonFields(builder);
        }

        private void ConfigurePermission(EntityTypeBuilder<Permission> builder)
        {
            builder.HasKey(p => p.PermissionId);

            builder.Property(p => p.PermissionName).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Description).HasMaxLength(255);

            ConfigureCommonFields(builder);
        }

        private void ConfigurePerson(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(p => p.PersonId);

            builder.OwnsOne(p => p.PersonalInfo, pi =>
            {
                pi.Property(pers => pers.FirstName).HasColumnName("FirstName").IsRequired().HasMaxLength(100);
                pi.Property(pers => pers.LastName).HasColumnName("LastName").IsRequired().HasMaxLength(100);
                pi.Property(pers => pers.DateOfBirth).HasColumnName("DateOfBirth");
                pi.Property(pers => pers.Gender).HasColumnName("Gender").HasMaxLength(10);
            });

            builder.Property(p => p.PhoneNumber).HasMaxLength(20);

            builder.OwnsOne(p => p.Address, addr =>
            {
                addr.Property(a => a.Value).HasColumnName("Address");
            });

            ConfigureCommonFields(builder);
        }

        private void ConfigureRole(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(r => r.RoleId);

            builder.Property(r => r.RoleName).IsRequired().HasMaxLength(50);
            builder.Property(r => r.Description).HasMaxLength(255);

            ConfigureCommonFields(builder);
        }

        private void ConfigureUserAccount(EntityTypeBuilder<UserAccount> builder)
        {
            builder.HasKey(u => u.UserAccountId);

            builder.Property(u => u.Username).IsRequired().HasMaxLength(100);

            builder.OwnsOne(u => u.Email, email =>
            {
                email.Property(e => e.Value).HasColumnName("Email").IsRequired();
            });

            builder.OwnsOne(u => u.Credentials, creds =>
            {
                creds.Property(c => c.PasswordHash).HasColumnName("PasswordHash").IsRequired();
                creds.Property(c => c.PasswordSalt).HasColumnName("PasswordSalt").IsRequired();
            });

            builder.Property(u => u.EmailConfirmed).IsRequired();
            builder.Property(u => u.IsActive).IsRequired();
            builder.Property(u => u.LastLoginAt);

            builder.HasOne(u => u.UserProfile)
                   .WithOne(up => up.UserAccount)
                   .HasForeignKey<UserProfile>(up => up.UserAccountId);

            ConfigureCommonFields(builder);
        }

        private void ConfigureUserProfile(EntityTypeBuilder<UserProfile> builder)
        {
            builder.HasKey(up => up.UserProfileId);

            builder.Property(up => up.UserType).IsRequired().HasMaxLength(50);
            builder.Property(up => up.EntityId).IsRequired();
            builder.Property(up => up.RoleId).IsRequired();
            builder.Property(up => up.IsActive).IsRequired();

            builder.HasOne(up => up.Role)
                   .WithMany()
                   .HasForeignKey(up => up.RoleId);

            builder.HasOne(up => up.UserAccount)
                   .WithOne(u => u.UserProfile)
                   .HasForeignKey<UserProfile>(up => up.UserAccountId);

            //// Configure new navigation collections:
            //builder.HasMany(up => up.OrphanOrgs)
            //       .WithOne(); // or specify inverse property if exists, e.g., .WithOne(oo => oo.UserProfile)
            //                   // .HasForeignKey(oo => oo.OrphanId); // Note: Adjust foreign key if needed

            //builder.HasMany(up => up.ManagerOrgs)
            //       .WithOne(); // or specify inverse property if exists, e.g., .WithOne(mo => mo.UserProfile)
            //      // .HasForeignKey(mo => mo.ManagerId); // Note: Adjust foreign key if needed

            ConfigureCommonFields(builder);
        }
        private void ConfigureRolePermission(EntityTypeBuilder<RolePermission> builder)
        {
            builder.ToTable("RolePermission", "UserRole");

            builder.HasKey(rp => rp.RolePermissionId);

            builder.Property(rp => rp.IsActive)
                   .IsRequired()
                   .HasDefaultValue(true);

            builder.HasOne(rp => rp.Role)
                   .WithMany()
                   .HasForeignKey(rp => rp.RoleId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(rp => rp.Permission)
                   .WithMany()
                   .HasForeignKey(rp => rp.PermissionId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Add a unique constraint to RoleId + PermissionId
            builder.HasIndex(rp => new { rp.RoleId, rp.PermissionId }).IsUnique();

            ConfigureCommonFields(builder);
        }

        //private void ConfigureRolePermission(EntityTypeBuilder<RolePermission> builder)
        //{
        //    builder.ToTable("RolePermission", "UserRole");

        //    builder.HasIndex(rp => new { rp.RoleId, rp.PermissionId }).IsUnique();


        //    builder.Property(rp => rp.IsActive)
        //           .IsRequired()
        //           .HasDefaultValue(true);

        //    builder.HasOne(rp => rp.Role)
        //           .WithMany()
        //           .HasForeignKey(rp => rp.RoleId)
        //           .OnDelete(DeleteBehavior.Cascade);

        //    builder.HasOne(rp => rp.Permission)
        //           .WithMany()
        //           .HasForeignKey(rp => rp.PermissionId)
        //           .OnDelete(DeleteBehavior.Cascade);

        //    ConfigureCommonFields(builder);
        //}

        private void ConfigureCommonFields<T>(EntityTypeBuilder<T> builder) where T : class, IHasModifiedInfo
        {
            builder.Property<bool>("IsActive").HasDefaultValue(true);

            builder.OwnsOne(e => e.ModifiedInfo, mi =>
            {
                mi.Property(m => m.Fcd).HasColumnName("Fcd").HasDefaultValueSql("getdate()");
                mi.Property(m => m.Lud).HasColumnName("Lud").HasDefaultValueSql("getdate()");
                mi.Property(m => m.Fcb).HasColumnName("Fcb");
                mi.Property(m => m.Lub).HasColumnName("Lub");
            });
        }
    }
}
