using Microsoft.EntityFrameworkCore;
using ODP_Studio_Api.Domain.Entities;
using ODP_Studio_Api.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODP_Studio_Api.Infrastructure.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<UserOrgRole> UserOrgRole { get; set; } = null!;
        public DbSet<Org> Orgs { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;

        // Add DbSet<T> for other entities as needed

        // Optional: Fluent API configurations can be added here or in separate config classes
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        
        {
            modelBuilder.Entity<User>( entity =>
            {
                entity.HasKey(e => e.UserID);

                entity.OwnsOne(u => u.Credentials, c =>
                {
                    c.Property(c => c.UserName).HasColumnName("UserName");
                    c.Property(c => c.Password).HasColumnName("Password");
                    c.Property(c => c.LoginPhone).HasColumnName("LoginPhone");
                    c.Property(c => c.LoginEmail).HasColumnName("LoginEmail");
                });

                entity.OwnsOne(u => u.PersonalInfo, pi =>
                {
                    pi.Property(p => p.FirstName).HasColumnName("FirstName");
                    pi.Property(p => p.LastName).HasColumnName("LastName"); ;
                    pi.Property(p => p.Age).HasColumnName("Age"); ;
                    pi.Property(p => p.City).HasColumnName("City"); ;
                    pi.Property(p => p.DateOfBirth).HasColumnName("DateOfBirth"); ;
                    pi.Property(p => p.GenderId).HasColumnName("GenderId"); ;
                    pi.Property(p => p.Nationality).HasColumnName("Nationality"); ;
                    pi.Property(p => p.Profession).HasColumnName("Profession"); ;
                });


                entity.OwnsOne(u => u.ContactInfo, ci =>
                {
                    ci.Property(c => c.PhoneNumber).HasColumnName("PhoneNum");
                    ci.Property(c => c.Email).HasColumnName("Email");
                });

                entity.OwnsOne(u => u.ModifiedInfo, mi =>
                {
                    mi.Property(c => c.Fcb).HasColumnName("fcb");
                    mi.Property(c => c.Lub).HasColumnName("lub");
                    mi.Property(c => c.Fcd).HasColumnName("fcd");
                    mi.Property(c => c.Fcb).HasColumnName("fcb");
                });

                entity.HasMany(e => e.UserOrgRoles)
                      .WithOne(uor => uor.User)
                      .HasForeignKey(uor => uor.UserID)
                      .OnDelete(DeleteBehavior.Cascade);
            });

           

            modelBuilder.Entity<UserOrgRole>(entity =>
            {
                entity.HasKey(e => e.UserOrgRoleID);

                entity.OwnsOne(u => u.ModifiedInfo, mi =>
                {
                    mi.Property(c => c.Fcb).HasColumnName("fcb");
                    mi.Property(c => c.Lub).HasColumnName("lub");
                    mi.Property(c => c.Fcd).HasColumnName("fcd");
                    mi.Property(c => c.Fcb).HasColumnName("fcb");
                });

                entity.HasOne(uor => uor.RoleType)
                      .WithMany()
                      .HasForeignKey(uor => uor.RoleTypeID)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(uor => uor.Org)
                      .WithMany()
                      .HasForeignKey(uor => uor.OrgID)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RoleTypeID);
                entity.Property(e => e.RoleType).IsRequired();

                entity.OwnsOne(u => u.ModifiedInfo, mi =>
                {
                    mi.Property(c => c.Fcb).HasColumnName("fcb");
                    mi.Property(c => c.Lub).HasColumnName("lub");
                    mi.Property(c => c.Fcd).HasColumnName("fcd");
                    mi.Property(c => c.Fcb).HasColumnName("fcb");
                });
            });

            modelBuilder.Entity<Org>(entity =>
            {
                entity.HasKey(e => e.OrgID);
                entity.Property(e => e.OrgName).IsRequired();

                entity.OwnsOne(u => u.ContactInfo, ci =>
                {
                    ci.Property(c => c.PhoneNumber).HasColumnName("PhoneNum");
                    ci.Property(c => c.Email).HasColumnName("Email");
                });

                entity.OwnsOne(u => u.ModifiedInfo, mi =>
                {
                    mi.Property(c => c.Fcb).HasColumnName("fcb");
                    mi.Property(c => c.Lub).HasColumnName("lub");
                    mi.Property(c => c.Fcd).HasColumnName("fcd");
                    mi.Property(c => c.Fcb).HasColumnName("fcb");
                });

            });


            base.OnModelCreating(modelBuilder);

            // E.g. modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
