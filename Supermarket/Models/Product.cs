using System.ComponentModel.DataAnnotations;

namespace Supermarket.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The Product Name field is required.")]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        public Category? Category { get; set; } 
    }
}
