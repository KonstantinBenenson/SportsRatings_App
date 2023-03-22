using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsRatings.Interfaces;
using SportsRatings.Models;
using SportsRatings.Models.ViewModels;
using SportsRatings.Services;

namespace SportsRatings.Controllers
{
    [Controller]
    [Route("{controller}/{action}")]
    public class SportController : Controller
    {
        private readonly ISportInterface _sService;
        public SportController(ISportInterface sService) //добавление сервиса для категорий ради наполнения SelectListItem, надо переделать?
        {
            _sService = sService;
        }

        public async Task<IActionResult> GetAllSports()
        {
            var sports = await _sService.GetAllSportsAsync();
            return View(sports);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSportsInCategory(int id) //+
        {
            var sportsVM = await _sService.GetAllSportsInCategoryAsync(id);

            if(sportsVM == null)
                return RedirectToAction("GetAllCategories", "Category");

            return View(sportsVM);
        }

        public IActionResult Create()
        {
            var createSportVM = _sService.GetCategoriesList();
            return View(createSportVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateSportDTO obj) //Почему ModelState выдает False, если все условия валидации соблюдены?
        {
            //if (!ModelState.IsValid)
            //    return View(obj);            

            await _sService.AddAsync(obj.Sport);
            return RedirectToAction(nameof(GetAllSports));
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            return View();
        }


        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            return View();
        }
    }
}
