using Microsoft.AspNetCore.Mvc.Rendering;

namespace SportsRatings.Models.DTO
{
    public class CreateTeamDTO
    {
        public TeamModel Team { get; set; }
        public IEnumerable<SelectListItem> Regions { get; set; }
        public IEnumerable<SelectListItem> Sports { get; set; }
    }
}
