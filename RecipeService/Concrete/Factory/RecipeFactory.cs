using RecipeServiceApi.Common.Models;

namespace RecipeServiceApi.Common.Contract.Factory
{
    public class RecipeFactory
    {
        public Recipe Create()
        {
            return new Recipe();
        }
    }
}
