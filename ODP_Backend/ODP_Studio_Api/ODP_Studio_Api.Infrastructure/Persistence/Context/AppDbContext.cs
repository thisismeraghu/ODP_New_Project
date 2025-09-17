using Microsoft.EntityFrameworkCore;
using ODP_Studio_Api.Domain.Entities;
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
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserID);
                entity.Property(e => e.FirstName).IsRequired();
                entity.Property(e => e.LastName).IsRequired();

                entity.HasMany(e => e.UserOrgRoles)
                      .WithOne(uor => uor.User)
                      .HasForeignKey(uor => uor.UserID)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<UserOrgRole>(entity =>
            {
                entity.HasKey(e => e.UserOrgRoleID);

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
            });

            modelBuilder.Entity<Org>(entity =>
            {
                entity.HasKey(e => e.OrgID);
                entity.Property(e => e.OrgName).IsRequired();
            });


            base.OnModelCreating(modelBuilder);

            // E.g. modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
