
using RecipeServiceApi.Common.Models;
using System.Collections.Generic;

namespace RecipeServiceApi.Concrete.DataAccess
{
    /// <summary>
    /// RecipeIngredientRepository
    /// </summary>
    public interface IRecipeIngredientRepository
    {
        /// <summary>
        /// Fetch a list of RecipeIngredients given a list of RecipeIds
        /// </summary>
        /// <param name="recipeIds"></param>
        /// <returns></returns>
        IEnumerable<IRecipeIngredient> FetchRecipeIngredients(IEnumerable<int> recipeIds);
    }
}
