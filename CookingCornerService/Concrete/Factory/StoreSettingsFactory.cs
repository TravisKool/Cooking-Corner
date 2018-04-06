using RecipeServiceApi.Common.Models;

namespace RecipeServiceApi.Common.Contract.Factory
{
    public class StoreSettingsFactory
    {
        public IStoreSettings Create()
        {
            return new StoreSettings();
        }
    }
}
