using Microsoft.AspNetCore.Mvc;
using Supermarket.Data;
using Supermarket.Models;

namespace Supermarket.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            List<Category> categories = CategoriesRepository.GetAllCategories().Data;

            if (categories == null || categories.Count == 0 )
            {
                return NotFound();
            }
            return View(categories);
        }

        public IActionResult Edit(int id)
        {
            var category = CategoriesRepository.GetCategoryById(id).Data;

            return View(category);
        }
    }
}
