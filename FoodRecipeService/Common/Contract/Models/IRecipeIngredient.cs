
namespace RecipeServiceApi.Common.Models
{
    /// <summary>
    /// RecipeIngredient
    /// </summary>
    public interface IRecipeIngredient
    {
        /// <summary>
        /// RecipeId
        /// </summary>
        int RecipeId { get; set; }

        /// <summary>
        /// Product
        /// </summary>
        IProduct Product { get; set; }

        /// <summary>
        /// Quantity
        /// </summary>
        decimal Quantity { get; set; }

        /// <summary>
        /// Units
        /// </summary>
        string Units { get; set; }
    }
}
