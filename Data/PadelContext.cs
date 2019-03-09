using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public class PadelContext : DbContext
    {
        public PadelContext(DbContextOptions<PadelContext> options) : base(options)
        {

        }
        public DbSet<Bro> Bros { get; set; }
        public DbSet<Match> Matches{ get; set; }
        public DbSet<MatchTeam> MatchTeams { get; set; }
        public DbSet<Team> Teams { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(
        //        "Server = (localdb)\\mssqllocaldb; Database = EfPadel; Trusted_Connection = True; ");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MatchTeam>().HasKey(mt => new { mt.MatchId, mt.TeamId });

        }

    }
}
