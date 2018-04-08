using RecipeServiceApi.Common.Models;

namespace RecipeServiceApi.Common.Contract.Factory
{
    /// <summary>
    /// ProductCategoryFactory
    /// </summary>
    public interface IProductCategoryFactory
    {
        /// <summary>
        /// Create ProductCategory
        /// </summary>
        /// <returns></returns>
        IProductCategory Create();
    }
}
