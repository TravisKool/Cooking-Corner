using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RecipeServiceApi.Common.Contract;
using RecipeServiceApi.Common.Response;

namespace RecipeService.Controllers
{
    [Route("api/[controller]")]
    public class RecipeController : Controller
    {
        private readonly IRecipeDataAccess _recipeDataAccess;

        public RecipeController(IRecipeDataAccess recipeDataAccess)
        {
            _recipeDataAccess = recipeDataAccess;
        }

        [HttpGet]
        public RecipeResponse GetRecipePrices()
        {
            return new RecipeResponse
            {
                Recipe = _recipeDataAccess.FetchRecipes()
            };
        }
    }
}
