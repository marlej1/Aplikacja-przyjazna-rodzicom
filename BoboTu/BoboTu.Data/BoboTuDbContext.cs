using BoboTu.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoboTu.Data
{
    public class BoboTuDbContext : IdentityDbContext<User,
        Role, int,
        IdentityUserClaim<int>,
        UserRole, IdentityUserLogin<int>,
        IdentityRoleClaim<int>,
        IdentityUserToken<int>>
    {
        public BoboTuDbContext(DbContextOptions<BoboTuDbContext> options) : base(options) { }

        public DbSet<Venue> Venues { get; set; }
        public DbSet<Opinion> Opinions { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<VenueFacility> VenueFacilities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<UserRole>(userRole =>
            {

                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId).IsRequired();

                userRole.HasOne(ur => ur.User)
               .WithMany(u => u.UserRoles)
               .HasForeignKey(ur => ur.UserId).IsRequired();
            });

            builder.Entity<VenueFacility>()
       .HasKey(vf => new { vf.VenueId, vf.FacilityId });
            builder.Entity<VenueFacility>()
                .HasOne(vf => vf.Facility)
                .WithMany(f => f.VenueFacilities)
                .HasForeignKey(vf => vf.FacilityId);
            builder.Entity<VenueFacility>()
                .HasOne(vf => vf.Venue)
                .WithMany(v => v.VenueFacilities)
                .HasForeignKey(vf => vf.VenueId);



         

        }

    }
}
