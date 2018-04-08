using RecipeServiceApi.Common.Models;

namespace RecipeServiceApi.Common.Contract.Factory
{
    public class ProductFactory : IProductFactory
    {
        public IProduct Create()
        {
            return new Product();
        }
    }
}
