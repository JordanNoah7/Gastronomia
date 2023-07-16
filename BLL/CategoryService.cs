using System.Collections.Generic;
using DAL;
using ML;

namespace BLL
{
    public class CategoryService
    {
        private readonly CategoryRepository _categoryRepository = new CategoryRepository();

        public List<Category> GetCategories()
        {
            return _categoryRepository.GetCategories();
        }
    }
}