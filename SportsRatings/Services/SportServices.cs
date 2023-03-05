using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportsRatings.Models;
using SportsRatings.Models.ViewModels;

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
            var sports = await _context.Sports.Include(x => x.Category).ToListAsync();
            return sports;
        }

        public async Task<GetSportsInCategoryDTO> GetAllSportsInCategoryAsync(int id)
        {
            var sports = await _context.Sports.Where(x => x.CategoryId == id).ToListAsync();

            var sportsVM = new GetSportsInCategoryDTO
            {
                Category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id),
                Sports = sports
            };

            if (sports == null)
                throw new ArgumentNullException(nameof(sports));

            return sportsVM;
        }

        public async Task<SportsModel> GetSportDetailsAsync(int id) //?
        {
            var sports = await _context.Sports.FindAsync(id);

            if (sports == null)
                throw new ArgumentNullException(nameof(sports));

            return sports;
        }
        public CreateSportDTO GetCategoriesList()
        {
            CreateSportDTO sportsVM = new CreateSportDTO()
            {
                Sport = new SportsModel(),
                Categories = _context.Categories.Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                })
            };
            return sportsVM;
        }

        public async Task<SportsModel> GetSportAsync(int? id)
        {
            var sport = await _context.Sports.FirstOrDefaultAsync(c => c.Id == id);

            if (sport == null)
                throw new ArgumentNullException(nameof(sport));

            return sport;
        }

        public async Task AddAsync(SportsModel obj)
        {
            await _context.Sports.AddAsync(obj);
            await _context.SaveChangesAsync();
        }

        //public async Task AddToCategoryAsync(int id, SportsModel obj)
        //{
        //    var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);


        //}

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

