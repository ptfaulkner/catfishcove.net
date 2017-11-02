using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CatfishCove.Web.Models;

namespace CatfishCove.Web.Data
{
    public class CatfishCoveDbContext : IdentityDbContext<ApplicationUser>
    {
        public CatfishCoveDbContext(DbContextOptions<CatfishCoveDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<FoodType> FoodTypes { get; set; }
        public DbSet<BuffetItem> BuffetItems { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<BuffetRotatingWeek> BuffetRotatingWeeks { get; set; }
        public DbSet<BuffetItemSchedule> BuffetSchedules { get; set; }
    }
}
