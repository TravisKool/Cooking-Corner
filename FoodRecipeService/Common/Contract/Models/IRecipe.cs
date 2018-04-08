
using System.Collections.Generic;

namespace RecipeServiceApi.Common.Models
{
    /// <summary>
    /// Recipe
    /// </summary>
    public interface IRecipe
    {
        /// <summary>
        /// RecipeId
        /// </summary>
        int RecipeId { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Ingredients
        /// </summary>
        IEnumerable<IRecipeIngredient> Ingredients { get; set; }

        /// <summary>
        /// Price
        /// </summary>
        IPrice Price { get; set; }
    }
}
