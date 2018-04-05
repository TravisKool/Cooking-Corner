using RecipeServiceApi.Common.Models;

namespace RecipeServiceApi.Common.Contract.Factory
{
    public class StoreSettingsFactory
    {
        public StoreSettings Create()
        {
            return new StoreSettings();
        }
    }
}
