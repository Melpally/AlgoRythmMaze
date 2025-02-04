using AlgoRythmMaze.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlgoRythmMaze.Infrastructure.Data.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder
                .Property(x => x.CreatedAt)
                .HasDefaultValueSql("GETDATE()")
                .HasPrecision(0);

            builder
                .HasOne(x => x.Caregiver)
                .WithMany()
                .HasForeignKey(x => x.CaregiverId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Client)
                .WithMany()
                .HasForeignKey(x => x.ClientId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
