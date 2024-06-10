﻿// <auto-generated />
using System;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApiContext))]
    [Migration("20240610075136_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Core.Entities.BusinessParticipant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("RegistryCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("BusinessParticipants");
                });

            modelBuilder.Entity("Core.Entities.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AdditionalInfo")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime>("BeginTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("BeginTime")
                        .HasDatabaseName("IX_Event_BeginTime");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Core.Entities.EventBusinessParticipant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AdditionalInfo")
                        .IsRequired()
                        .HasMaxLength(50000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BusinessParticipantId")
                        .HasColumnType("int");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<byte>("PaymentType")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("BusinessParticipantId");

                    b.HasIndex("EventId");

                    b.ToTable("EventBusinessParticipants");
                });

            modelBuilder.Entity("Core.Entities.EventPrivateParticipant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AdditionalInfo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<byte>("PaymentType")
                        .HasColumnType("tinyint");

                    b.Property<int>("PrivateParticipantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("PrivateParticipantId");

                    b.ToTable("EventPrivateParticipants");
                });

            modelBuilder.Entity("Core.Entities.PrivateParticipant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PersonalCode")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("Id");

                    b.ToTable("PrivateParticipants");
                });

            modelBuilder.Entity("Core.Entities.EventBusinessParticipant", b =>
                {
                    b.HasOne("Core.Entities.BusinessParticipant", "BusinessParticipant")
                        .WithMany("EventBusinessParticipants")
                        .HasForeignKey("BusinessParticipantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Event", "Event")
                        .WithMany("EventBusinessParticipants")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BusinessParticipant");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("Core.Entities.EventPrivateParticipant", b =>
                {
                    b.HasOne("Core.Entities.Event", "Event")
                        .WithMany("EventPrivateParticipants")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.PrivateParticipant", "PrivateParticipant")
                        .WithMany("EventPrivateParticipants")
                        .HasForeignKey("PrivateParticipantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("PrivateParticipant");
                });

            modelBuilder.Entity("Core.Entities.BusinessParticipant", b =>
                {
                    b.Navigation("EventBusinessParticipants");
                });

            modelBuilder.Entity("Core.Entities.Event", b =>
                {
                    b.Navigation("EventBusinessParticipants");

                    b.Navigation("EventPrivateParticipants");
                });

            modelBuilder.Entity("Core.Entities.PrivateParticipant", b =>
                {
                    b.Navigation("EventPrivateParticipants");
                });
#pragma warning restore 612, 618
        }
    }
}
