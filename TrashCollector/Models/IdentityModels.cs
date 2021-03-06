﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace TrashCollector.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public int RoleId { get; set; }
        public string Address { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Zip { get; set; }
        public DayOfWeek Pickupday { get; set; }
        public DateTime EnrollDate { get; internal set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<TrashCollector.Models.CustomerViewModel> Customers { get; set; }

        public System.Data.Entity.DbSet<TrashCollector.Models.Workers> Workers { get; set; }

        public System.Data.Entity.DbSet<TrashCollector.Models.Schedule> Schedules { get; set; }

        

        public System.Data.Entity.DbSet<TrashCollector.Models.Pricing> Pricings { get; set; }

        public System.Data.Entity.DbSet<TrashCollector.Models.MapPickupModel> MapPickupModels { get; set; }
    }
}