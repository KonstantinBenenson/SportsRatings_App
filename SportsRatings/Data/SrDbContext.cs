using Microsoft.EntityFrameworkCore;
using SportsRatings.Data.Configurations;
using SportsRatings.Models;

namespace SportsRatings
{
    public class SrDbContext : DbContext
    {
        //Sport ratings DbContext
        public SrDbContext(DbContextOptions<SrDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RegionsConfiguration());

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<SportModel> Sports { get; set; }
        public DbSet<TeamModel> Teams { get; set; }
        public DbSet<PlayerModel> Players { get; set; }
        public DbSet<RegionModel> Regions { get; set; }
    }
}
