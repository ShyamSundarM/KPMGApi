using KPMGApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KPMGApi
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext()
        {
            
        }
        public DbSet<Browser> Browsers { get; set; }
        public DbSet<JobEmployment> JobEmployments { get; set; }
        public DbSet<RainTimeline> RainTimeline { get; set; }  

        public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
