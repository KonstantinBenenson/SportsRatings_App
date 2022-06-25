using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsRatings.Models.ViewModels;
using SportsRatings.Services;

namespace SportsRatings.Controllers
{
    [Controller]
    [Route("[controller]/[action]")]
    public class TeamController : Controller
    {
        private readonly TeamServices _service;
        public TeamController(TeamServices service)
        {
            _service = service;
        }        

        public IActionResult Create() //+
        {
            var teamVM =_service.CreatTeamObjectWithSelectLists();
            return View(teamVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateSportVM obj) //
        {
            return RedirectToAction(nameof(GetTeamsInSport));
        }

        public IActionResult Edit(int id) //
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, CreateSportVM newObj) //
        {
            return View();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeamsInSport(int id)
        {
            if(id == 0)
                return BadRequest();
            
            var teamsWithSport = await _service.GetTeamsInSportAsync(id);
            
            if (teamsWithSport is null)
                return NotFound();
            
            return View(teamsWithSport);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        // POST: TeamController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TeamController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TeamController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
