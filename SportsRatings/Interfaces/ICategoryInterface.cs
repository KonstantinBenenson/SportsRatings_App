using Microsoft.EntityFrameworkCore;
using SportsRatings.Models;

namespace SportsRatings.Interfaces
{
    public interface ICategoryInterface
    {
        public Task<CategoriesModel> GetCategoryAsync(int? id);

        public Task<IEnumerable<CategoriesModel>> GetAllCategoriesAsync();

        public Task AddAsync(CategoriesModel obj);

        public Task UpdateAsync(int id, CategoriesModel newObj);

        public Task RemoveAsync(CategoriesModel obj);

        public Task<bool> CheckIfExistsAsync(string name);
    }
}
