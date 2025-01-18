using AlgoRythmMaze.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlgoRythmMaze.Infrastructure.Data.Configurations
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder
                .Property(x => x.CreatedAt)
                .HasDefaultValueSql("GETDATE()")
                .HasPrecision(0);

            builder
                .HasOne(x => x.Service)
                .WithMany()
                .HasForeignKey(x => x.ServiceId);

            builder
                .HasOne(x => x.Caregiver)
                .WithMany()
                .HasForeignKey(x => x.CaregiverId);

            builder
                .HasOne(x => x.Client)
                .WithMany()
                .HasForeignKey(x => x.ClientId);
        }
    }
}