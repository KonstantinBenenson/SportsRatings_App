using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using SportsRatings.Controllers;
using SportsRatings.Interfaces;
using SportsRatings.Models;
using SportsRatings.Services;

namespace SportsRatings.Tests
{
    public class CategoryController_Tests
    {
        private readonly ICategoryInterface _catService;
        private readonly ISportInterface _sportService;
        private readonly CategoryController _catCtrl;     
        public CategoryController_Tests()       
        {
            // Faking services
            _catService = A.Fake<ICategoryInterface>();
            _sportService = A.Fake<ISportInterface>();

            // Controller
            _catCtrl = new CategoryController(_catService, _sportService);
        }

        // Check if we can successfully go to the View after creating a new Category
        [Fact]
        public void CategoryCtrl_CreatePOST_ReturnsSuccess()
        {
            // Arrange
            var newCategory = A.Fake<CategoriesModel>();

            // Act
            var result = _catCtrl.CreatePOST(newCategory);

            // Assert
            newCategory.Should().NotBeNull();

            result.Should().BeOfType<Task<IActionResult>>();

            result.Result.Should().NotBeOfType<OkObjectResult>();
            result.Result.Should().NotBeOfType<RedirectToActionResult>();
            result.Result.Should().BeOfType<ViewResult>();
        }

        // Check if we successfully returning to the View a list of categories
        [Fact]
        public void CategoryCtrl_GetAllCategories_ReturnsSuccess()
        {
            // Arrange
            var categories = A.Fake<IEnumerable<CategoriesModel>>();
            A.CallTo(() => _catService.GetAllCategoriesAsync()).Returns(categories);

            // Act
            var result = _catCtrl.GetAllCategories();

            // Assert
            result.Should().BeOfType<Task<IActionResult>>();
            result.Result.Should().BeOfType<ViewResult>();
        }
    }
}