using AlgoRythmMaze.Domain.Entities;
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
        public DbSet<CaregiverProfile> Quizzes { get; set; }
        public DbSet<Booking> Levels { get; set; }
        public DbSet<Payment> Projects { get; set; }
        public DbSet<Service> Interests { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<CaregiverService> InterestUsers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyMarker).Assembly);

        }
    }
}
