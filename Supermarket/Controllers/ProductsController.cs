using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Supermarket.Data;
using Supermarket.Models;
using System.Reflection;

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
            ProductViewModel viewModel = new ProductViewModel();
            ViewBag.Categories = new SelectList(CategoriesRepository.GetAllCategories().Data, "Id", "Name");
            ViewBag.Action = "Add";
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
            ViewBag.Categories = new SelectList(CategoriesRepository.GetAllCategories().Data, "Id", "Name");
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            ProductsRepository.Remove(id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Categories = new SelectList(CategoriesRepository.GetAllCategories().Data, "Id", "Name");
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
            var category = CategoriesRepository.GetCategoryById(productViewModel.CategoryId).Data;

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

        public IActionResult ProductsByCategoryPartial(int categoryId)
        {
            var products = ProductsRepository.GetProductsByCategoryId(categoryId);

            ViewBag.Role = "Cashier";

            return PartialView("_Products",products);
        }

        [HttpGet]
        public IActionResult SellProductPartial(int productId)
        {
            var product = ProductsRepository.GetById(productId);
            return PartialView("_SellProduct", product);
        }

    }
}
