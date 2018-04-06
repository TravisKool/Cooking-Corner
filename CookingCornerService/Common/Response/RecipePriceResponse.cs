using RecipeServiceApi.Common.Models;
using System.Collections.Generic;

namespace RecipeServiceApi.Common.Response
{
    public class RecipeResponse
    {
        public IEnumerable<IRecipe> Recipe { get; set; }
    }
}
