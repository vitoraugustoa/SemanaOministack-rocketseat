using API_ToBeHero.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_ToBeHero.Context
{
    public class HeroDbContext : DbContext
    {
        public HeroDbContext(DbContextOptions<HeroDbContext> options) : base(options)
        {}

        public virtual DbSet<Incident> Incident { get; set; }
        public virtual DbSet<Ong> Ong { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ong>(e =>
            {
                e.ToTable("ongs");
                e.HasMany(o => o.Incidents).WithOne(o => o.IncidentOng).HasForeignKey(o => o.IdOng);
            });

            modelBuilder.Entity<Incident>(e =>
            {
                e.ToTable("incidents");
            });
        }
    }
}
