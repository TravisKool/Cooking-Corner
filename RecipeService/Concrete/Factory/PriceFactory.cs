using RecipeServiceApi.Common.Models;

namespace RecipeServiceApi.Common.Contract.Factory
{
    public class PriceFactory : IPriceFactory
    {
        public IPrice Create(IRecipe recipe, IStoreSettings storeSettings)
        {
            return new RecipePrice(recipe, storeSettings);
        }
    }
}
