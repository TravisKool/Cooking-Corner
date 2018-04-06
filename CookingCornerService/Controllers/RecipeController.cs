using System.Web.Http;
using RecipeServiceApi.Common.Contract;
using RecipeServiceApi.Common.Response;

namespace RecipeService.Controllers
{
    [Route("[controller]")]
    public class RecipeController
    {
        private readonly IRecipeDataAccess _recipeDataAccess;

        public RecipeController(IRecipeDataAccess recipeDataAccess)
        {
            _recipeDataAccess = recipeDataAccess;
        }

        [HttpGet]
        public RecipeResponse Get()
        {
            return new RecipeResponse
            {
                Recipe = _recipeDataAccess.FetchRecipes()
            };
        }
    }
}
