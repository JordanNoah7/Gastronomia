﻿using System.Data;
using DAL;
using ML;

namespace BLL
{
    public class RecipeService
    {
        private readonly RecipeRepository _recipeRepository = new RecipeRepository();

        public DataTable GetRecipes()
        {
            return _recipeRepository.GetRecipes();
        }

        public bool AddRecipe(Recipe recipe)
        {
            return _recipeRepository.AddRecipe(recipe);
        }

        public bool DeleteRecipe(int id)
        {
            return _recipeRepository.DeleteRecipe(id);
        }

        public Recipe GetRecipe(int id)
        {
            return _recipeRepository.GetRecipe(id);
        }

        public bool UpdateRecipe(Recipe recipe)
        {
            return _recipeRepository.UpdateRecipe(recipe);
        }
    }
}