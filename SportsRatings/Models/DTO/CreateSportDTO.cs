using Microsoft.AspNetCore.Mvc.Rendering;

namespace SportsRatings.Models.ViewModels
{
    public class CreateSportDTO
    {
        public SportsModel Sport { get; set; } = null!;       
        public IEnumerable<SelectListItem> Categories { get; set; } = null!;
    }
}
