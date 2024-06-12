using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.FluentConfig {
    public class BusinessParticipantConfig : IEntityTypeConfiguration<BusinessParticipant> {
        public void Configure(EntityTypeBuilder<BusinessParticipant> builder) {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();

            builder.Property(b => b.Name).HasMaxLength(100).IsRequired();
            builder.Property(b => b.RegistryCode).HasMaxLength(20).IsRequired();
            builder.Property(b => b.AdditionalInfo).HasMaxLength(5000).IsRequired();
            builder.Property(b => b.PaymentType).IsRequired();
        }
    }
}
