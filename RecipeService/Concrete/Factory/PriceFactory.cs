using RecipeServiceApi.Common.Models;

namespace RecipeServiceApi.Common.Contract.Factory
{
    public class PriceFactory : IPriceFactory
    {
        public RecipePrice Create(IRecipe recipe, IStoreSettings storeSettings)
        {
            return new RecipePrice(recipe, storeSettings);
        }
    }
}
