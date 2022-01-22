using EntityFrameworkNet5.Data.Configurations.Entities;
using EntityFrameworkNet5.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace EntityFrameworkNet5.Data
{
    public class FootballLeageDbContext : AuditableFootballLeageDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=FootballLeage_EfCore")
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
                .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeamsCoachesLeaguesView>().HasNoKey().ToView("TeamsCoachesLeagues");
            modelBuilder.ApplyConfiguration(new LeagueConfiguration());
            modelBuilder.ApplyConfiguration(new TeamConfiguration());
            modelBuilder.ApplyConfiguration(new CoachConfiguration());

            //Set all FK relationships should be restrict
            var foreignKeys = modelBuilder.Model.GetEntityTypes()
                .SelectMany(x => x.GetForeignKeys())
                .Where(x => !x.IsOwnership && x.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in foreignKeys)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }

            //Indicate which has a History Table
            modelBuilder
                .Entity<Team>()
                .ToTable("Teams", b => b.IsTemporal());

        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            // Pre-convention model configuration goes here
            ////configurationBuilder.Properties<string>().HaveMaxLength(50);
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<TeamsCoachesLeaguesView> TeamsCoachesLeagues { get; set; }

    }
}
