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
    }
}
