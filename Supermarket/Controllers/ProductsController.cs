using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            ViewBag.Categories = CategoriesRepository.GetAllCategories().Data;
            ProductViewModel viewModel = new ProductViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Add(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var category = CategoriesRepository.GetCategoryById(model.CategoryId).Data;
                var product = new Product
                {
                    Name = model.Name,
                    Price = model.Price,
                    Quantity = model.Quantity,
                    CategoryId = model.CategoryId,
                    Category = category
                };
                ProductsRepository.Add(product);
                return RedirectToAction(nameof(Index));
            }
            model.AvailableCategories = new SelectList(CategoriesRepository.GetAllCategories().Data, "Id", "Name");
            return View(model);
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
            ProductViewModel viewModel = new ProductViewModel() { 
                
                Id = id,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,    
                CategoryId = product.CategoryId,

            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(ProductViewModel productViewModel)
        {
            var category = CategoriesRepository.GetCategoryById(productViewModel.Id).Data;

            var product = new Product()
            {
                Id = productViewModel.Id,
                Name = productViewModel.Name,
                Price = productViewModel.Price,
                Quantity = productViewModel.Quantity,
                CategoryId = productViewModel.CategoryId,
                Category = category
            };

            ProductsRepository.Update(product);
            return RedirectToAction(nameof(Index));
        }

    }
}
