using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsRatings.Models;
using SportsRatings.Models.DTO;
using SportsRatings.Services;

namespace SportsRatings.Controllers
{
    [Controller]
    [Route("{controller}/{action}")]
    public class SportController : Controller
    {
        private readonly SportServices _sService;
        public SportController(SportServices sService) //добавление сервиса для категорий ради наполнения SelectListItem, надо переделать?
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

            if (sportsVM == null)
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
        [ActionName("CreatePost")]
        public async Task<IActionResult> Create(CreateSportDTO obj) //Почему ModelState выдает False, если все условия валидации соблюдены?
        {
            //if (!ModelState.IsValid)
            //    return View(obj);            

            await _sService.AddAsync(obj.Sport);
            return RedirectToAction(nameof(GetAllSports));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var sport = await _sService.GetSportAsync(id);

            if (sport is null)
                return NotFound();

            return View(sport);
        }

        [HttpPost("/{id}")]
        [ValidateAntiForgeryToken]
        [ActionName("EditPost")]
        public async Task<IActionResult> Edit(int id, GetOrUpdateSportDTO sport)
        {
            if (ModelState.IsValid && sport is not null)
            {
                await _sService.UpdateAsync(id, sport.SportModel);
                return RedirectToAction(nameof(GetAllSports));
            }

            ModelState.AddModelError("ModelStateError", "Возникла ошибка при обновлении. Попробуйте еще раз.");
            return View(sport);
        }

        //public async Task<IActionResult> Delete(int? id) 
        //{
        //    if (id is not null)
        //    {
        //        var sport = await _sService?.GetSportAsync(id); 
        //        return RedirectToAction(nameof(Delete), sport.SportModel);
        //    }
        //    return RedirectToAction(nameof(GetAllSports));
        //}

        [HttpPost("/{id}")]
        [ValidateAntiForgeryToken]
        [ActionName("DeletePost")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null)
                return NotFound();

            await _sService.RemoveAsync(id);
            return RedirectToAction(nameof(GetAllSports));
        }
    }
}
