using Microsoft.EntityFrameworkCore;
using SportsRatings.Models;

namespace SportsRatings
{
    public class SrDbContext : DbContext
    {
        //Sport ratings DbContext
        public SrDbContext(DbContextOptions<SrDbContext> options) : base(options)
        {

        }

        public DbSet<SportCategoriesModel> Categories { get; set; }
        public DbSet<SportsModel> Sports { get; set; }
    }
}
