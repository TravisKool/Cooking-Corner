
using RecipeServiceApi.Common.Models;
using System.Collections.Generic;

namespace RecipeServiceApi.Common.Contract
{
    /// <summary>
    ///  Recipe Data Access
    /// </summary>
    public interface IRecipeDataAccess
    {
        /// <summary>
        /// Fetche a list of existing Recipes
        /// </summary>
        /// <returns></returns>
        IEnumerable<IRecipe> FetchRecipes();
    }
}
