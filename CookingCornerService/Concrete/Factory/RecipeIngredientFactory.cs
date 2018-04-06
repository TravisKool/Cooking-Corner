using RecipeServiceApi.Common.Models;

namespace RecipeServiceApi.Common.Contract.Factory
{
    public class RecipeIngredientFactory : IRecipeIngredientFactory
    {
        public IRecipeIngredient Create()
        {
            return new RecipeIngredient();
        }
    }
}
