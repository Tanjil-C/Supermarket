using Microsoft.AspNetCore.Mvc;
using Supermarket.Data;
using Supermarket.Models;

namespace Supermarket.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            var response = CategoriesRepository.GetAllCategories();


            if (response.Success != true)
            {
                return NoContent();
            }
            
            return View(response.Data);
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";

            var category = CategoriesRepository.GetCategoryById(id).Data;

            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                var response = CategoriesRepository.UpdateCategory(category);

                if (response.Success != true)
                {
                    return NoContent();
                }

                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        public IActionResult Add()
        {
            ViewBag.Action = "Add";

            Category model = new Category();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            if (ModelState.IsValid)
            {
                var response = CategoriesRepository.AddCategory(category);

                if (response.Success == true)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(category);
        }

        public IActionResult Delete(int id)
        {
            CategoriesRepository.RemoveCategory(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public Category GetCategoryById(int id)
        {
            return CategoriesRepository.GetCategoryById(id).Data;
        }
    }
}
