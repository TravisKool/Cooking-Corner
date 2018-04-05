using RecipeServiceApi.Common.Models;

namespace RecipeServiceApi.Common.Contract.Factory
{
    /// <summary>
    /// PriceFactory
    /// </summary>
    public interface IPriceFactory
    {
        /// <summary>
        /// Create Price
        /// </summary>
        /// <returns></returns>
        RecipePrice Create(IRecipe recipe, IStoreSettings storeSettings);
    }
}
