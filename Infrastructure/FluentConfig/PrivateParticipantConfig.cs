using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.FluentConfig {
    public class PrivateParticipantConfig : IEntityTypeConfiguration<PrivateParticipant> {
        public void Configure(EntityTypeBuilder<PrivateParticipant> builder) {
            builder.HasKey(e => e.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();

            builder.Property(b => b.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(b => b.LastName).HasMaxLength(50).IsRequired();
            builder.Property(b => b.PersonalCode).HasMaxLength(11).IsRequired();
            builder.HasIndex(b => b.PersonalCode).IsUnique().HasDatabaseName("IX_PersonalCode");
        }
    }
}
