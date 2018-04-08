
using RecipeServiceApi.Common.Models;
using System.Collections.Generic;

namespace RecipeServiceApi.Common.Contract
{
    /// <summary>
    ///  Recipe Data Access
    /// </summary>
    public interface IProductDataAccess
    {
        /// <summary>
        /// Fetche a list of existing Recipes
        /// </summary>
        /// <returns></returns>
        IEnumerable<IProduct> FetchProducts();
    }
}
