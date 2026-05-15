using Microsoft.EntityFrameworkCore;
using Project5Day.WebApi.Entities;

namespace Project5Day.WebApi.Context
{
    public class ApiContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(local)\\SQLEXPRESS;Initial Catalog=ApiDbDay1;Integrated Security=true;TrustServerCertificate=True");
        }

        // Mevcut tabloların
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }

        // Football tabloları
        public DbSet<Team> Teams { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<MatchEvent> MatchEvents { get; set; }
        public DbSet<MatchStatistic> MatchStatistics { get; set; }
        public DbSet<LeagueTable> LeagueTables { get; set; }

        // 🔥 KRİTİK İLİŞKİ AYARI
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>()
                .HasOne(x => x.HomeTeam)
                .WithMany(x => x.HomeMatches)
                .HasForeignKey(x => x.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Match>()
                .HasOne(x => x.AwayTeam)
                .WithMany(x => x.AwayMatches)
                .HasForeignKey(x => x.AwayTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<LeagueTable>()
    .HasOne(x => x.Team)
    .WithMany()
    .HasForeignKey(x => x.TeamId);
        }

    }
}