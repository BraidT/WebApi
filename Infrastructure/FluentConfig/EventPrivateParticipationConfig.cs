using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.FluentConfig {
    public class EventPrivateParticipationConfig : IEntityTypeConfiguration<EventPrivateParticipant> {
        public void Configure(EntityTypeBuilder<EventPrivateParticipant> builder) {
            builder.HasKey(e => e.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();

            builder.HasOne(ep => ep.Event)
                         .WithMany(e => e.EventPrivateParticipants)
                         .HasForeignKey(ep => ep.EventId)
                         .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(ep => ep.PrivateParticipant)
                         .WithMany(bp => bp.EventPrivateParticipants)
                         .HasForeignKey(ep => ep.PrivateParticipantId)
                         .OnDelete(DeleteBehavior.Cascade);
            builder.Property(b => b.AdditionalInfo).HasMaxLength(1500);
            builder.Property(b => b.PaymentType).IsRequired();
        }
    }
}
