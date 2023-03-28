using Microsoft.AspNetCore.Mvc.Rendering;

namespace SportsRatings.Models.DTO
{
    public class GetOrUpdateSportDTO
    {
        public SportModel SportModel { get; set; } = null!;     
        public IEnumerable<SelectListItem> Categories { get; set; } = null!;
    }
}
