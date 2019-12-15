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
    [DbContext(typeof(PadelContext))]
    [Migration("20190309115954_init4")]
    partial class init4
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
                    b.Property<int>("BroId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int?>("TeamId");

                    b.HasKey("BroId");

                    b.HasIndex("TeamId");

                    b.ToTable("Bros");
                });

            modelBuilder.Entity("Domain.Match", b =>
                {
                    b.Property<int>("MatchId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ResultId");

                    b.HasKey("MatchId");

                    b.HasIndex("ResultId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("Domain.MatchTeam", b =>
                {
                    b.Property<int>("MatchId");

                    b.Property<int>("TeamId");

                    b.HasKey("MatchId", "TeamId");

                    b.HasIndex("TeamId");

                    b.ToTable("MatchTeams");
                });

            modelBuilder.Entity("Domain.Rank", b =>
                {
                    b.Property<int>("RankId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BroId");

                    b.Property<decimal>("Ranking");

                    b.HasKey("RankId");

                    b.HasIndex("BroId");

                    b.ToTable("Ranks");
                });

            modelBuilder.Entity("Domain.Result", b =>
                {
                    b.Property<int>("ResultId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("SetsCountTeam1");

                    b.Property<int>("SetsCountTeam2");

                    b.Property<int>("Winner");

                    b.HasKey("ResultId");

                    b.ToTable("Result");
                });

            modelBuilder.Entity("Domain.Set", b =>
                {
                    b.Property<int>("SetId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ResultId");

                    b.Property<int>("TeamOneGems");

                    b.Property<int>("TeamTwoGems");

                    b.Property<int>("Winner");

                    b.HasKey("SetId");

                    b.HasIndex("ResultId");

                    b.ToTable("Set");
                });

            modelBuilder.Entity("Domain.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("TeamId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Domain.Bro", b =>
                {
                    b.HasOne("Domain.Team")
                        .WithMany("Bros")
                        .HasForeignKey("TeamId");
                });

            modelBuilder.Entity("Domain.Match", b =>
                {
                    b.HasOne("Domain.Result", "Result")
                        .WithMany()
                        .HasForeignKey("ResultId");
                });

            modelBuilder.Entity("Domain.MatchTeam", b =>
                {
                    b.HasOne("Domain.Match", "Match")
                        .WithMany("MatchTeams")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Team", "Team")
                        .WithMany("MatchTeams")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Rank", b =>
                {
                    b.HasOne("Domain.Bro")
                        .WithMany("Ranks")
                        .HasForeignKey("BroId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Set", b =>
                {
                    b.HasOne("Domain.Result")
                        .WithMany("Sets")
                        .HasForeignKey("ResultId");
                });
#pragma warning restore 612, 618
        }
    }
}
