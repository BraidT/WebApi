using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.FluentConfig {
    public class EventConfig : IEntityTypeConfiguration<Event> {
        public void Configure(EntityTypeBuilder<Event> builder) {
            builder.HasKey(e => e.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();

            builder.Property(b => b.Name).HasMaxLength(100);
            builder.Property(b => b.BeginTime).IsRequired();
            builder.HasIndex(e => e.BeginTime)
                         .HasDatabaseName("IX_Event_BeginTime");
            builder.Property(b => b.AdditionalInfo).HasMaxLength(1000);
            builder.Property(b=> b.Location).IsRequired().HasMaxLength(200);
        }
    }
}
