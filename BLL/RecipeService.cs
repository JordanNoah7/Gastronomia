using System.Data;
using DAL;

namespace BLL
{
    public class RecipeService
    {
        private readonly RecipeRepository _recipeRepository = new RecipeRepository();

        public DataTable GetRecipes()
        {
            return _recipeRepository.GetRecipes();
        }
    }
}