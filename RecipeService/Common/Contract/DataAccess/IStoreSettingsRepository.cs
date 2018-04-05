
using RecipeServiceApi.Common.Models;

namespace RecipeServiceApi.Concrete.DataAccess
{
    /// <summary>
    /// StoreSettingsRepository
    /// </summary>
    public interface IStoreSettingsRepository
    {
        /// <summary>
        /// Fetch the store settings
        /// </summary>
        /// <returns></returns>
        IStoreSettings FetchStoreSettings();
    }
}
