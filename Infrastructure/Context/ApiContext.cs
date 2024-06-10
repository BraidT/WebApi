using Core.Entities;
using Core.Enums;
using Infrastructure.FluentConfig;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Infrastructure.Context {
    public class ApiContext : DbContext {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new BusinessParticipantConfig());
            modelBuilder.ApplyConfiguration(new EventBusinessParticipantConfig());
            modelBuilder.ApplyConfiguration(new EventConfig());
            modelBuilder.ApplyConfiguration(new EventBusinessParticipantConfig());
            modelBuilder.ApplyConfiguration(new PrivateParticipantConfig());

           // AddSeedData(modelBuilder);
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<EventBusinessParticipant> EventBusinessParticipants { get; set; }
        public DbSet<EventPrivateParticipant> EventPrivateParticipants { get; set; }
        public DbSet<PrivateParticipant> PrivateParticipants { get; set; }
        public DbSet<BusinessParticipant> BusinessParticipants { get; set; }

        private void AddSeedData(ModelBuilder modelBuilder) {

            var privateParticipant1 = new PrivateParticipant { FirstName = "John", LastName = "Doe", PersonalCode = "11111" };
            var privateParticipant2 = new PrivateParticipant { FirstName = "Jane", LastName = "Smith", PersonalCode = "22222" };
            var privateParticipant3 = new PrivateParticipant { FirstName = "Bob", LastName = "Brown", PersonalCode = "33333" };

            var businessParticipant1 = new BusinessParticipant { Name = "TechCorp", RegistryCode = "registry code 1" };
            var businessParticipant2 = new BusinessParticipant { Name = "BizInc", RegistryCode = "registry code 2" };

            var event1 = new Event { Name = "Past Event 1", BeginTime = DateTime.Now.AddMonths(-2), Location = "Location A", AdditionalInfo = "Info A" };
            var event2 = new Event { Name = "Past Event 2", BeginTime = DateTime.Now.AddMonths(-1), Location = "Location B", AdditionalInfo = "Info B" };
            var event3 = new Event { Name = "Future Event 1", BeginTime = DateTime.Now.AddMonths(1), Location = "Location C", AdditionalInfo = "Info C" };
            var event4 = new Event { Name = "Future Event 2", BeginTime = DateTime.Now.AddMonths(2), Location = "Location D", AdditionalInfo = "Info D" };
            var event5 = new Event { Name = "Future Event 3", BeginTime = DateTime.Now.AddMonths(3), Location = "Location E", AdditionalInfo = "Info E" };

            var eventPrivateParticipants = new List<EventPrivateParticipant> {
            new EventPrivateParticipant { Event = event1, PrivateParticipant = privateParticipant1, AdditionalInfo = "Info 1", PaymentType = PaymentTypeEnum.Cash },
            new EventPrivateParticipant { Event = event2, PrivateParticipant = privateParticipant2, AdditionalInfo = "Info 2", PaymentType = PaymentTypeEnum.Card },
            new EventPrivateParticipant { Event = event3, PrivateParticipant = privateParticipant3, AdditionalInfo = "Info 3", PaymentType = PaymentTypeEnum.Cash }
                 };

            var eventBusinessParticipants = new List<EventBusinessParticipant> {
            new EventBusinessParticipant { Event = event1, BusinessParticipant = businessParticipant1, AdditionalInfo = "Info 1", PaymentType = PaymentTypeEnum.Card },
            new EventBusinessParticipant { Event = event2, BusinessParticipant = businessParticipant2, AdditionalInfo = "Info 2", PaymentType = PaymentTypeEnum.Cash },
            new EventBusinessParticipant { Event = event3, BusinessParticipant = businessParticipant1, AdditionalInfo = "Info 3", PaymentType = PaymentTypeEnum.Card },
            new EventBusinessParticipant { Event = event3, BusinessParticipant = businessParticipant2, AdditionalInfo = "Info 4", PaymentType = PaymentTypeEnum.Card }
        };

            modelBuilder.Entity<PrivateParticipant>().HasData(privateParticipant1, privateParticipant2, privateParticipant3);
            modelBuilder.Entity<BusinessParticipant>().HasData(businessParticipant1, businessParticipant2);
            modelBuilder.Entity<Event>().HasData(event1, event2, event3, event4, event5);
            modelBuilder.Entity<EventPrivateParticipant>().HasData(eventPrivateParticipants);
            modelBuilder.Entity<EventBusinessParticipant>().HasData(eventBusinessParticipants);
        }
    }
}
