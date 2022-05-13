using SportsRatings.Models;

namespace SportsRatings.Services
{
    public class SportServices
    {
        private readonly SrDbContext _context;
        public SportServices(SrDbContext context)
        {
            _context = context;
        }

        public async Task<SportCategoriesModel> GetCategoryDetails(int id)
        {
            var sports = await _context.Categories.FindAsync(id);
            return sports;
        }

    }
}
