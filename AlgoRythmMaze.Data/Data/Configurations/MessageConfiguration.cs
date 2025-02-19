using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TopiTopi.Domain.Entities;

namespace TopiTopi.Infrastructure.Data.Configurations
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder
                .Property(x => x.SentAt)
                .HasDefaultValueSql("GETDATE()")
                .HasPrecision(0);

            builder
                .HasOne(x => x.Chat)
                .WithMany()
                .HasForeignKey(x => x.ChatId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Sender)
                .WithMany()
                .HasForeignKey(x => x.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Receiver)
                .WithMany()
                .HasForeignKey(x => x.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
