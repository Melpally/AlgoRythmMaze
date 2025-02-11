using AlgoRythmMaze.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlgoRythmMaze.Infrastructure.Data.Configurations
{
    public class ClientProfileConfiguration : IEntityTypeConfiguration<ClientProfile>
    {
        public void Configure(EntityTypeBuilder<ClientProfile> builder)
        {
            builder
                .HasOne(c => c.User)
                .WithOne(c => c.ClientProfile)
                .HasForeignKey<ClientProfile>(x => x.Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(c => c.ServicesNeeded)
                .WithMany(c => c.Clients)
                .UsingEntity("ClientService");

        }
    }
}
