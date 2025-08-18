using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Pilot> Pilots { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pilot>()
                .HasOne(p => p.Team)
                .WithMany(t => t.Pilots)
                .HasForeignKey(p => p.TeamId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
