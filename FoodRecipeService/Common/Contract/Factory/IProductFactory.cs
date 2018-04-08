using RecipeServiceApi.Common.Models;

namespace RecipeServiceApi.Common.Contract.Factory
{
    /// <summary>
    /// ProductFactory
    /// </summary>
    public interface IProductFactory
    {
        /// <summary>
        /// Create Product
        /// </summary>
        /// <returns></returns>
        IProduct Create();
    }
}
