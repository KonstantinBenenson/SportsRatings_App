using Microsoft.AspNetCore.Mvc.Rendering;

namespace SportsRatings.Models.ViewModels
{
    public class CreateTeamVM
    {
        public TeamsModel Team { get; set; }
        public IEnumerable<SelectListItem> Regions { get; set; }
        public IEnumerable<SelectListItem> Sports { get; set; }
    }
}
