using RecipeServiceApi.Common.Models;

namespace RecipeServiceApi.Common.Contract.Factory
{
    public class ProductFactory
    {
        public Product Create()
        {
            return new Product();
        }
    }
}
