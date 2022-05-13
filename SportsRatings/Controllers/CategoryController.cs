using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsRatings.Models;
using SportsRatings.Services;

namespace SportsRatings.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryServices _catService;
        private readonly SportServices _spService;

        [TempData]
        private string Message { get; set; } = string.Empty;

        public CategoryController(CategoryServices cs, SportServices ss)
        {
            _catService = cs;
            _spService = ss;
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> CreateAndRedirect(SportCategoriesModel obj)
        //{
        //    if(!ModelState.IsValid)
        //        return View(obj);
        //    try
        //    {
        //        await _catService.AddAsync(obj);
        //        return RedirectToAction("Create", "Sport", obj.Id); //Нужно ли писать SportController полностью?
        //    }
        //    catch
        //    {
        //        //Logging
        //        return View();
        //    }            
        //}

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SportCategoriesModel obj)
        {
            if (!ModelState.IsValid)
                return View();

            if(await _catService.CheckIfExistsAsync(obj.Name)) //If object exists - returns TRUE
                return View();

            try
            {
                await _catService.AddAsync(obj);
                TempData["Message"] = $"New category {obj.Name} was successfully created."; //?????????
                return View();
            }
            catch
            {
                //Logging
                return View();
            }
        }

        // GET
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _catService.GetAllCategoriesAsync();
            return View(categories);
        }

        // GET: CategoryController/Category
        public async Task<IActionResult> GetCategoryInfo(int id)
        {
            try
            {
                var categoryInfo = await _spService.GetCategoryDetails(id);
                return View(categoryInfo);

            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }               
        

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CategoryController/Edit/5
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

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null | id == 0)
                return NotFound();

            try
            {
                var category = await _catService.ReturnCategoryAsync(id);
                if(category == null)
                    return NotFound();

                return View(category);
            }
            catch (Exception ex)
            {
                //Logging
                return View();
                throw new ArgumentException(ex.Message);
            }            
        }

        // GET: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var category = await _catService.ReturnCategoryAsync(id);

            if(category == null)
                return NotFound(category);

            await _catService.RemoveAsync(category);
            return RedirectToAction("GetAllCategories");
        }
    }
}
