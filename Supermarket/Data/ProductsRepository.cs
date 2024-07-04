using Supermarket.Models;

namespace Supermarket.Data
{
    public static class ProductsRepository
    {
        private static readonly List<Product> _products = new List<Product>()
        {
            new Product{ Id = 1, Name = "Sourdough Bread", Price = 3.99, Quantity = 50, Category = CategoriesRepository.GetCategoryById(1).Data, CategoryId = 1},
            new Product{ Id = 2, Name = "Croissant", Price = 1.49, Quantity = 80, Category = CategoriesRepository.GetCategoryById(1).Data, CategoryId = 1},
            new Product{ Id = 3, Name = "Ribeye Steak", Price = 15.99, Quantity = 40, Category = CategoriesRepository.GetCategoryById(2).Data, CategoryId = 2},
            new Product{ Id = 4, Name = "Chicken Breast", Price = 5.49, Quantity = 70, Category = CategoriesRepository.GetCategoryById(2).Data, CategoryId = 2},
            new Product{ Id = 5, Name = "Coca Cola", Price = 0.99, Quantity = 150, Category = CategoriesRepository.GetCategoryById(3).Data, CategoryId = 3},
            new Product{ Id = 6, Name = "Orange Juice", Price = 2.99, Quantity = 90, Category = CategoriesRepository.GetCategoryById(3).Data, CategoryId = 3},
            new Product{ Id = 7, Name = "Water Bottle", Price = 0.49, Quantity = 200, Category = CategoriesRepository.GetCategoryById(3).Data, CategoryId = 3},
            new Product{ Id = 8, Name = "Lemonade", Price = 1.99, Quantity = 120, Category = CategoriesRepository.GetCategoryById(3).Data, CategoryId = 3}
        };

        public static List<Product> GetAllProducts()
        {
            return _products;
        }

        public static bool Add(Product product)
        {

            try
            {
                int id = _products.Max(x => x.Id) + 1;

                product.Id = id;

                _products.Add(product);
                return true;
            }catch(Exception ex)
            {
                return false;
            }

        }

        public static void Remove(int id)
        {
            var product = _products.FirstOrDefault(x => x.Id == id);

            _products.Remove(product);

        }

        public static void Update(Product product)
        {
            var index = _products.FindIndex(x => x.Id == product.Id);
            _products[index] = product;
        }

        public static Product GetById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public static List<Product> GetProductsByCategoryId(int categoryId)
        {
            var products = _products.Where(x => x.CategoryId == categoryId).ToList();

            return products;
        }
    }
}
