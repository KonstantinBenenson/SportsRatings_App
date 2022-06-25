namespace SportsRatings.Models.ViewModels
{
    public class GetSportsInCategoryVM
    {
        public CategoriesModel Category { get; set; } = null!;
        public IEnumerable<SportsModel> Sports { get; set; } = null!;
    }
}
