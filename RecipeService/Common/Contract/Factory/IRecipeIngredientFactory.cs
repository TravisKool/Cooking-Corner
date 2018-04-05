using RecipeServiceApi.Common.Models;

namespace RecipeServiceApi.Common.Contract.Factory
{
    /// <summary>
    /// RecipeIngredientFacotyr
    /// </summary>
    public interface IRecipeIngredientFactory
    {
        /// <summary>
        /// Create RecipeIngredient
        /// </summary>
        /// <returns></returns>
        RecipeIngredient Create();
    }
}
