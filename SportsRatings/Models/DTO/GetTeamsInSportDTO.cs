namespace SportsRatings.Models.ViewModels
{
    public class GetTeamsInSportDTO
    {
        public SportsModel Sport { get; set; } = null!;
        public IEnumerable<TeamsModel> Teams { get; set; } = null!;
    }
}
