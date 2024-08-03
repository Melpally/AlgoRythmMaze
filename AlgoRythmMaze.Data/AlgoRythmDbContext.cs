using AlgoRythmMaze.Domain.Models;
using AlgoRythmMaze.Infrastructure.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AlgoRythmMaze.Infrastructure
{
    public class AlgoRythmDbContext : IdentityDbContext<User>
    {
        public AlgoRythmDbContext(DbContextOptions<AlgoRythmDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyMarker).Assembly);

        }
    }
}
