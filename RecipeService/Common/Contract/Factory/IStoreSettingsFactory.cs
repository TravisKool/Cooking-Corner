using RecipeServiceApi.Common.Models;

namespace RecipeServiceApi.Common.Contract.Factory
{
    /// <summary>
    /// StoreSettingsFactory
    /// </summary>
    public interface IStoreSettingsFactory
    {
        /// <summary>
        /// Create StoreSettings
        /// </summary>
        /// <returns></returns>
        IStoreSettings Create();
    }
}
