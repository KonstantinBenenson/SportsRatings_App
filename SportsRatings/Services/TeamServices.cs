using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportsRatings.Models;
using SportsRatings.Models.ViewModels;

namespace SportsRatings.Services
{
    public class TeamServices
    {
        private readonly SrDbContext _context;
        public TeamServices(SrDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TeamsModel team)
        {
            await _context.Teams.AddAsync(team);
            await _context.SaveChangesAsync();
        }

        public CreateTeamDTO CreatTeamObjectWithSelectLists()
        {
            var team = new CreateTeamDTO
            {
                Team = new TeamsModel(),
                Sports = GetSports(),
                Regions = GetRegions()
            };
            return team;
        }

        private IEnumerable<SelectListItem> GetSports()
        {
            return _context.Sports.Select(s => new SelectListItem
            {
                Text = s.Name,
                Value = s.Id.ToString()
            });
        }

        private IEnumerable<SelectListItem> GetRegions()
        {
            return _context.Regions.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id.ToString()
            });
        }

        public async Task<GetTeamsInSportDTO> GetTeamsInSportAsync(int id)
        {
            var teams = await _context.Teams.Where(t => t.SportId == id).ToListAsync();

            var sportsVM = new GetTeamsInSportDTO
            {
                Sport = await _context.Sports.FirstOrDefaultAsync(s => s.Id == id),
                Teams = teams
            };

            return sportsVM;
        }
    }
}
