using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<SportsModel>> GetAllSportsAsync()
        {
            var sports = await _context.Sports.ToListAsync();
            return sports;
        }

        public async Task<IEnumerable<SportsModel>> GetAllSportsInCategoryAsync(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            var sports = category.Sports.ToList();

            return sports;
        }

        public async Task<SportsModel> GetSportDetails(int id)
        {
            var sports = await _context.Sports.FindAsync(id);

            if (sports == null)
                throw new ArgumentNullException(nameof(sports));

            return sports;
        }

        public async Task<SportsModel> ReturnSportAsync(int? id)
        {
            var sport = await _context.Sports.FirstOrDefaultAsync(c => c.Id == id);

            if(sport == null)
                throw new ArgumentNullException(nameof(sport));

            return sport;
        }        

        public async Task AddAsync(SportsModel obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            await _context.Sports.AddAsync(obj);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(SportsModel obj)
        {
            _context.Sports.Remove(obj);
            await _context.SaveChangesAsync();
        }

        //Checks if database contains an object with the given name. 
        //Returns TRUE if object is not a null, so EXISTS.
        public async Task<bool> CheckIfExistsAsync(string name)
        {
            var obj = await _context.Sports.FirstOrDefaultAsync(c =>
                c.Name.ToLower() == name.ToLower());

            return obj != null;
        }
    }
}

