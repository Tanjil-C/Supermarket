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

            Response<List<Category>> data = new Response<List<Category>>(copyOfCategories);
            data.Success = true;

            return data;
        }

        public static Response<Category> AddCategory(Category category)
        {
            // Get All categories

            try
            {
                var maxId = 0;
                maxId = _categories.Max(c => c.Id);

                category.Id = maxId + 1;

                _categories.Add(category);

                return new Response<Category>(category) { Success = true };
            }
            catch (Exception ex)
            {
                return new Response<Category>(category) { Message = "Failed Add Category", Success = false };
            }

        }

        public static Response<Category>? GetCategoryById(int id)
        {
            var category = _categories.FirstOrDefault(x => x.Id == id);

            var copy = category;

            if (category == null)
            {
                return new Response<Category>() { Message = "This category was not found. ", Success = false };
            }

            return new Response<Category>(copy) { Success = true };
        }

        public static Response<Category>? RemoveCategory(int id)
        {
            var category = GetCategoryById(id).Data;

            if (category != null)
            {
                _categories.Remove(category);

                return new Response<Category>() { Message = $"Removal of category {category.Name} was sucessful. ", Success = true };

            }

            return new Response<Category>() { Success = false } ;
        }

        public static Response<Category>? UpdateCategory(Category category)
        {

            try
            {
                var copyId = _categories.FindIndex(x => x.Id == category.Id); // "=" is assigning and "==" is a bool comparison

                _categories[copyId] = category;

                if (_categories.Contains(category))
                {
                    return new Response<Category>(category)
                    {
                        Success = true
                    };
                }

                return new Response<Category>() { Success = false };

                
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error occured in repository updating category. ", ex);
            }
            

        
        }
    }
}
