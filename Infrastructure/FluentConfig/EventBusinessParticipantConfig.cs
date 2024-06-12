using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.FluentConfig {
    public class EventBusinessParticipantConfig : IEntityTypeConfiguration<EventBusinessParticipant> {
        public void Configure(EntityTypeBuilder<EventBusinessParticipant> builder) {
            builder.HasKey(e => e.Id);
            builder.Property(b => b.Id) .ValueGeneratedOnAdd();

            builder.HasOne(ep => ep.Event)
                         .WithMany(e => e.EventBusinessParticipants)
                         .HasForeignKey(ep => ep.EventId);
            builder.HasOne(ep => ep.BusinessParticipant)
                         .WithMany(bp => bp.EventBusinessParticipants)
                         .HasForeignKey(ep => ep.BusinessParticipantId);
            builder.Property(b => b.AdditionalInfo).HasMaxLength(5000);
            builder.Property(b => b.PaymentType).IsRequired();

            builder.HasIndex(ep => ep.EventId);
            builder.HasIndex(ep => ep.BusinessParticipantId);
        }
    }
}
