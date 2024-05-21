using Supermarket.Models;

namespace Supermarket.Data
{

    // static class means we do not have to create a new instance everytime we want to access this repo
    public static class CategoriesRepository
    {

        private static List<Category> _categories = new List<Category>()
        {
            new Category{ Id = 1, Name = "Bakery", Description = "Fresh baked goods." },
            new Category{ Id = 2, Name = "Meat", Description = "Fresh meats"},
            new Category{ Id = 3, Name = "Beverage", Description = "Wide range of beverages"}
        };

        public static Response<List<Category>> GetAllCategories()
        {
            // simulating a DB, a DB returns copies of the requested data
            List<Category> copyOfCategories = _categories;
            return new Response<List<Category>>(copyOfCategories);
        }

        public static Response<Category> AddCategory(Category category)
        {
            // Get All categories

            try
            {
                var maxId = _categories.Max(x => category.Id);

                category.Id = maxId + 1;

                return new Response<Category>(category);
            }
            catch (Exception ex)
            {
                return new Response<Category>(category){Message = "Failed Add Category" };
            }

        }

        public static Response<Category>? GetCategoryById(int id)
        {
            var category = _categories.FirstOrDefault(x => x.Id == id);

            var copy = category;

            if (category == null)
            {
                return new Response<Category>() { Message = "This category was not found. " }; 
            }

            return new Response<Category>(copy);
        }

        public static Response<Category>? RemoveCategory(int id)
        {
            var category = GetCategoryById(id).Data;

            if (category != null)
            {
                _categories.Remove(category);

                return new Response<Category>() { Message = $"Removal of category {category.Name} was sucessful. "};

            }

            return null; 
        }

    }
}
