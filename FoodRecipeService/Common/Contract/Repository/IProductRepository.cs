
using RecipeServiceApi.Common.Models;
using System.Collections.Generic;

namespace RecipeServiceApi.Concrete.Repository
{
    /// <summary>
    /// IProductRepository
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Fetch a list of all existing Recipes
        /// </summary>
        /// <returns></returns>
        IEnumerable<IProduct> FetchProducts();
    }
}
