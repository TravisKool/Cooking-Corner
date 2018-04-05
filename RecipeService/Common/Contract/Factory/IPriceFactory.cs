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
        IPrice Create(IRecipe recipe, IStoreSettings storeSettings);
    }
}
