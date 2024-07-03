using Microsoft.AspNetCore.Mvc;
using Supermarket.Data;
using Supermarket.Models;

namespace Supermarket.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            List<Product> products = ProductsRepository.GetAllProducts(); 
            return View(products);
        }

        public IActionResult Add()
        {
            ViewBag.Categories = CategoriesRepository.GetAllCategories().Data; // Ensure this method call is successful and returns data
            ViewBag.Action = "Add";
            return View(new Product());
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = CategoriesRepository.GetAllCategories().Data;
                ViewBag.Action = "Add";
                return View(product);
            }

            ProductsRepository.Add(product);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            ProductsRepository.Remove(id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Categories = CategoriesRepository.GetAllCategories().Data;
            ViewBag.Action = "Edit";
            var product = ProductsRepository.GetById(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            var category = CategoriesRepository.GetCategoryById(product.Category.Id).Data;
            product.Category = category;  // Reassign the category based on ID
            ProductsRepository.Update(product);
            return RedirectToAction(nameof(Index));
        }

    }
}
