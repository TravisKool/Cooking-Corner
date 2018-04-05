using RecipeServiceApi.Common.Models;

namespace RecipeServiceApi.Common.Contract.Factory
{
    public class RecipeIngredientFactory : IRecipeIngredientFactory
    {
        public RecipeIngredient Create()
        {
            return new RecipeIngredient();
        }
    }
}
