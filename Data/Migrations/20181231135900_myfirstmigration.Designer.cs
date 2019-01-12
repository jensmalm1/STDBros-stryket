﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(TippContext))]
    [Migration("20181231135900_myfirstmigration")]
    partial class myfirstmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Bro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Bros");
                });

            modelBuilder.Entity("Domain.Match", b =>
                {
                    b.Property<int>("MatchNr")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AwayTeam");

                    b.Property<string>("HomeTeam");

                    b.Property<int>("Result");

                    b.Property<int?>("WeekNr");

                    b.HasKey("MatchNr");

                    b.HasIndex("WeekNr");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("Domain.Week", b =>
                {
                    b.Property<int>("WeekNr")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BroId");

                    b.HasKey("WeekNr");

                    b.HasIndex("BroId");

                    b.ToTable("Weeks");
                });

            modelBuilder.Entity("Domain.Match", b =>
                {
                    b.HasOne("Domain.Week")
                        .WithMany("Matches")
                        .HasForeignKey("WeekNr");
                });

            modelBuilder.Entity("Domain.Week", b =>
                {
                    b.HasOne("Domain.Bro")
                        .WithMany("Weeks")
                        .HasForeignKey("BroId");
                });
#pragma warning restore 612, 618
        }
    }
}