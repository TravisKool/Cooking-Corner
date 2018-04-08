using RecipeServiceApi.Common.Models;

namespace RecipeServiceApi.Common.Contract.Factory
{
    public class RecipeFactory : IRecipeFactory
    {
        public IRecipe Create()
        {
            return new Recipe();
        }
    }
}
