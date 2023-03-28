using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportsRatings.Models;
using SportsRatings.Models.DTO;

namespace SportsRatings.Services
{
    public class CategoryServices
    {
        private readonly SrDbContext _context;
        public CategoryServices(SrDbContext context)
        {
            _context = context;
        }

        public async Task<CategoryModel> GetCategoryAsync(int? id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            return category;
        }

        public async Task<IEnumerable<CategoryModel>> GetAllCategoriesAsync()
        {
            var categories = await _context.Categories.ToListAsync();
            return categories;
        }      

        public async Task AddAsync(CategoryModel obj)
        {
            if(obj == null)
                throw new ArgumentNullException(nameof(obj));

            await _context.Categories.AddAsync(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, CategoryModel newObj)
        {
            //var obj = await GetCategoryAsync(id);
            _context.Categories.Update(newObj);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(CategoryModel obj)
        {
            _context.Categories.Remove(obj);
            await _context.SaveChangesAsync();
        }

        //Checks if database contains an object with the given name. 
        //Returns TRUE if object is not a null, thus EXISTS.
        public async Task<bool> CheckIfExistsAsync(string name) 
        {
            return await _context.Categories.AnyAsync(c =>
                c.Name.ToLower() == name.ToLower());
        }
    }
}
