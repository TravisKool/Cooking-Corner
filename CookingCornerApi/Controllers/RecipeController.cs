using RecipeServiceApi.Common.Contract;
using RecipeServiceApi.Common.Response;
using System.Web.Http;

namespace RecipeService.Controllers
{
    public class RecipeController : ApiController
    {
        private readonly IRecipeDataAccess _recipeDataAccess;

        public RecipeController(IRecipeDataAccess recipeDataAccess)
        {
            _recipeDataAccess = recipeDataAccess;
        }

        [HttpGet]
        public RecipeResponse FetchAllRecipes()
        {
            return new RecipeResponse
            {
                Recipes = _recipeDataAccess.FetchRecipes()
            };
        }
    }
}
