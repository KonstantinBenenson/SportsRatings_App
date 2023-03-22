using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportsRatings.Models.ViewModels;
using SportsRatings.Models;

namespace SportsRatings.Interfaces
{
    public interface ISportInterface
    {
        public Task<IEnumerable<SportsModel>> GetAllSportsAsync();

        public Task<GetSportsInCategoryDTO> GetAllSportsInCategoryAsync(int id);

        public Task<SportsModel> GetSportDetailsAsync(int id);

        public CreateSportDTO GetCategoriesList();

        public Task<SportsModel> GetSportAsync(int? id);

        public Task AddAsync(SportsModel obj);

        //public Task AddToCategoryAsync(int id, SportsModel obj);

        public Task RemoveAsync(SportsModel obj);

        public Task<bool> CheckIfExistsAsync(string name);
    }
}
