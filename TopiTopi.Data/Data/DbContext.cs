using AlgoRythmMaze.Domain.Models;
using AlgoRythmMaze.Infrastructure.Data.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AlgoRythmMaze.Infrastructure.Data
{
    public class DbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public DbContext(DbContextOptions<DbContext> options) : base(options) { }

        public DbContext() { }

        public DbSet<CaregiverProfile> Topics { get; set; }
        public DbSet<Service> Levels { get; set; }
        public DbSet<Payment> Projects { get; set; }
        public DbSet<CaregiverService> TopicXPs { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Booking> ProjectTopics { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyMarker).Assembly);

        }
    }
}
