using Microsoft.EntityFrameworkCore;
using SportsRatings.Models;

namespace SportsRatings.Services
{
    public class CategoryServices
    {
        private readonly SrDbContext _context;
        public CategoryServices(SrDbContext context)
        {
            _context = context;
        }

        public async Task<SportCategoriesModel> ReturnCategoryAsync(int? id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            return category;
        }

        public async Task<IEnumerable<SportCategoriesModel>> GetAllCategoriesAsync()
        {
            var categories = await _context.Categories.ToListAsync();
            return categories;
        }

        public async Task AddAsync(SportCategoriesModel obj)
        {
            if(obj == null)
                throw new ArgumentNullException(nameof(obj));

            await _context.Categories.AddAsync(obj);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(SportCategoriesModel obj)
        {
            _context.Categories.Remove(obj);
            await _context.SaveChangesAsync();
        }

        //Checks if database contains an object with the given name. 
        //Returns TRUE if object is not a null, so EXISTS.
        public async Task<bool> CheckIfExistsAsync(string name) 
        {
            var obj = await _context.Categories.FirstOrDefaultAsync(c => 
                c.Name.ToLower() == name.ToLower());  

            return obj != null;
        }
    }
}
