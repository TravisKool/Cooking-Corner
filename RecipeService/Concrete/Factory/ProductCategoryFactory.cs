using RecipeServiceApi.Common.Models;

namespace RecipeServiceApi.Common.Contract.Factory
{
    public class ProductCategoryFactory : IProductCategoryFactory
    {
        public ProductCategory Create()
        {
            return new ProductCategory();
        }
    }
}
