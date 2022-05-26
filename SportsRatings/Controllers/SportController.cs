using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsRatings.Models;
using SportsRatings.Services;

namespace SportsRatings.Controllers
{
    public class SportController : Controller
    {
        private readonly SportServices _sService;
        public SportController(SportServices sService)
        {
            _sService = sService;   
        }

        public async Task<IActionResult> GetAllSports()
        {
            var sports = await _sService.GetAllSportsAsync();
            return View(sports);
        }

        // GET: SportController
        [HttpGet]
        public async Task<IActionResult> GetSportsInCategory(int id)
        {
            var sports = await _sService.GetAllSportsInCategoryAsync(id);

            if(sports == null)
                return RedirectToAction("GetAllCategories", "Category");

            return View(sports);
        }

        // GET: SportController/2
        [HttpGet("{id}")]
        public IActionResult GetSport(int id)
        {
            return View();
        }


        // GET: SportController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        // GET: SportController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SportController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePost(IFormCollection collection)
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


        // GET: SportController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SportController/Edit/5
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


        // GET: SportController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SportController/Delete/5
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
