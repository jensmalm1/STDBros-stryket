using Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data
{
    public class PadelContext : DbContext
    {
        public DbSet<Bro> Bros { get; set; }
        public DbSet<Match> Matches{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server = (localdb)\\mssqllocaldb; Database = EfPadel; Trusted_Connection = True; ");
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Bro>
        //}

    }
}
