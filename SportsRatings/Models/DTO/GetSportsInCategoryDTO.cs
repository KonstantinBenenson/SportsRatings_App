namespace SportsRatings.Models.DTO
{
    public class GetSportsInCategoryDTO
    {
        public CategoryModel Category { get; set; } = null!;
        public IEnumerable<SportModel> Sports { get; set; } = null!;
    }
}
