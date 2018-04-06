using RecipeServiceApi.Common.Contract;
using RecipeServiceApi.Common.Contract.Factory;
using RecipeServiceApi.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeServiceApi.Concrete.DataAccess
{
    public class RecipeDataAccess : IRecipeDataAccess
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IRecipeIngredientRepository _recipeIngredientRepository;
        private readonly IStoreSettingsRepository _storeSettingsRepository;
        private readonly IPriceFactory _priceFactory;

        public RecipeDataAccess(IRecipeRepository recipeRepository,
            IRecipeIngredientRepository recipeIngredientRepository,
            IStoreSettingsRepository storeSettingsRepository,
            IPriceFactory priceFactory)
        {
            _recipeRepository = recipeRepository;
            _recipeIngredientRepository = recipeIngredientRepository;
            _storeSettingsRepository = storeSettingsRepository;
            _priceFactory = priceFactory;
        }

        public IEnumerable<IRecipe> FetchRecipes()
        {
            var recipes = _recipeRepository.FetchRecipes();
            var storeSettings = _storeSettingsRepository.FetchStoreSettings();

            foreach(var recipe in recipes)
            {
                recipe.Ingredients = _recipeIngredientRepository.FetchRecipeIngredients(new List<int> { recipe.RecipeId });
                recipe.Price = _priceFactory.Create(recipe, storeSettings);
            }

            return recipes;
        }
    }
}
