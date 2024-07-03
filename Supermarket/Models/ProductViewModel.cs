using Microsoft.AspNetCore.Mvc.Rendering;

namespace Supermarket.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }

        public IEnumerable<SelectListItem> AvailableCategories { get; set; }
    }
}
