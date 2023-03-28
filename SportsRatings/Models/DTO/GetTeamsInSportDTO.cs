namespace SportsRatings.Models.DTO
{
    public class GetTeamsInSportDTO
    {
        public SportModel Sport { get; set; } = null!;
        public IEnumerable<TeamModel> Teams { get; set; } = null!;
    }
}
