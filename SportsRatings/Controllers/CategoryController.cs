using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsRatings.Interfaces;
using SportsRatings.Models;
using SportsRatings.Services;

namespace SportsRatings.Controllers
{
    [Controller]
    [Route("{controller}/{action}")]
    public class CategoryController : Controller
    {
        private readonly ICategoryInterface _catService;
        private readonly ISportInterface _spService;

        [TempData]
        private string Message { get; set; } = string.Empty;

        public CategoryController(ICategoryInterface cs, ISportInterface ss)
        {
            _catService = cs;
            _spService = ss;
        }

        public ActionResult Create()
        {
            return View();
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> CreateAndRedirect(CategoriesModel obj)
        //{
        //    if (!ModelState.IsValid)
        //        return View(obj);
        //    if (await _catService.CheckIfExistsAsync(obj.Name)) //If object exists - returns TRUE
        //        return View(nameof(Create));

        //    try
        //    {
        //        await _catService.AddAsync(obj);
        //        return RedirectToAction("Create", "Sport", obj.Id); //Нужно ли писать SportController полностью?
        //    }
        //    catch
        //    {
        //        Logging
        //        return View();
        //    }
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePOST(CategoriesModel obj)
        {
            if (!ModelState.IsValid)
                return View();
            if (await _catService.CheckIfExistsAsync(obj.Name)) //If object exists - returns TRUE
                return View(nameof(Create));

            try
            {
                await _catService.AddAsync(obj);
                TempData["Message"] = $"New category {obj.Name} was successfully created."; //?????????
                return RedirectToAction(nameof(GetAllCategories));
            }
            catch
            {
                //Logging
                return View();
            }
        }

        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _catService.GetAllCategoriesAsync();
            return View(categories);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id == 0)
                return View();

            var category = await _catService.GetCategoryAsync(id);

            if (category == null)
                return View();

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPOST(int id, CategoriesModel obj)
        {
            await _catService.UpdateAsync(id, obj);
            return RedirectToAction(nameof(GetAllCategories)); //вывод сообщения в клиент об успешном обновлении ИЛИ ошибке?
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null | id == 0)
                return NotFound();

            try
            {
                var category = await _catService.GetCategoryAsync(id);

                return View(category);
            }
            catch (Exception ex)
            {
                //Logging
                return RedirectToAction(nameof(GetAllCategories));
                throw new ArgumentException(ex.Message);
            }
        }

        // GET: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePOST(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var category = await _catService.GetCategoryAsync(id);

            if (category == null)
                return NotFound(category);

            await _catService.RemoveAsync(category);
            return RedirectToAction(nameof(GetAllCategories));
        }       
    
    }    
}
