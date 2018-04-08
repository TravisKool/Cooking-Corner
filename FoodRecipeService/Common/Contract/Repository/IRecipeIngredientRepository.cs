
using RecipeServiceApi.Common.Models;
using System.Collections.Generic;

namespace RecipeServiceApi.Concrete.Repository
{
    /// <summary>
    /// RecipeIngredientRepository
    /// </summary>
    public interface IRecipeIngredientRepository
    {
        /// <summary>
        /// Fetch a list of RecipeIngredients given a list of RecipeIds
        /// </summary>
        /// <param name="recipeId"></param>
        /// <returns></returns>
        IEnumerable<IRecipeIngredient> FetchRecipeIngredients(int recipeId);
    }
}
