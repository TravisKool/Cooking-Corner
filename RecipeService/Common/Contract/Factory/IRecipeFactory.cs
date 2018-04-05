using RecipeServiceApi.Common.Models;

namespace RecipeServiceApi.Common.Contract.Factory
{
    /// <summary>
    /// RecipeFactory
    /// </summary>
    public interface IRecipeFactory
    {
        /// <summary>
        /// Create Recipe
        /// </summary>
        /// <returns></returns>
        Recipe Create();
    }
}
