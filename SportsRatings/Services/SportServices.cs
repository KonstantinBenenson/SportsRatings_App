using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportsRatings.Models;
using SportsRatings.Models.DTO;

namespace SportsRatings.Services
{
    public class SportServices
    {
        private readonly SrDbContext _context;
        public SportServices(SrDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SportModel>> GetAllSportsAsync()
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

        public async Task<SportModel> GetSportDetailsAsync(int id) //?
        {
            var sports = await _context.Sports.FindAsync(id);

            if (sports == null)
                throw new ArgumentNullException(nameof(sports));

            return sports;
        }

        public CreateSportDTO GetCategoriesList()
        {
            return new CreateSportDTO()
            {
                Sport = new SportModel(),
                Categories = GetSelectListItem()
            };
        }

        private IQueryable<SelectListItem> GetSelectListItem()
        {
            return _context.Categories.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            });
        }

        public async Task<GetOrUpdateSportDTO> GetSportAsync(int? id)
        {
            var sport = await _context.Sports.FindAsync(id);

            if (sport == null)
                throw new ArgumentNullException(nameof(sport));

            return ToDTO(sport);
        }

        /// <summary>
        /// Transforms a normal SportModel object to the GetOrUpdateSportDTO Object.
        /// </summary>
        /// <param name="sport"></param>
        /// <returns></returns>
        private GetOrUpdateSportDTO ToDTO(SportModel sport)
        {
            return new GetOrUpdateSportDTO()
            {
                SportModel = sport,
                Categories = GetCategoriesList().Categories
            };
        }

        public async Task AddAsync(SportModel obj)
        {
            await _context.Sports.AddAsync(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(int id, SportModel sport) // Решить, нужен ли DTO для обновления/получения или обойтись обычным SportModel ???
        {
            if (sport is not null)
            {
                sport.Id = id;
                _context.Sports.Update(sport);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }


        //public async Task AddToCategoryAsync(int id, SportsModel obj)
        //{
        //    var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);


        //}

        public async Task RemoveAsync(SportModel obj)
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

