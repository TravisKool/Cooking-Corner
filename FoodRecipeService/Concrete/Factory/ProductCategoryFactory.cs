using RecipeServiceApi.Common.Models;

namespace RecipeServiceApi.Common.Contract.Factory
{
    public class ProductCategoryFactory : IProductCategoryFactory
    {
        public IProductCategory Create()
        {
            return new ProductCategory();
        }
    }
}
