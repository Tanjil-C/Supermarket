using Microsoft.AspNetCore.Mvc;
using Supermarket.Data;
using Supermarket.Models;

namespace Supermarket.Controllers
{
    public class SalesController : Controller
    {
        public IActionResult Index()
        {
            SalesViewModel model = new SalesViewModel() {
                Categories = CategoriesRepository.GetAllCategories().Data
            };
            return View(model);
        }

        public IActionResult Sell(SalesViewModel salesViewModel)
        {
            if (ModelState.IsValid)
            {
                // sell product
            }

            // not valid, return to view

            return View("Index", salesViewModel);
        }
    }
}
