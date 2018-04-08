using RecipeServiceApi.Common.Models;
using System;
using System.Collections.Generic;

namespace RecipeServiceApi.Common.Response
{
    [Serializable]
    public class RecipeResponse
    {
        public IEnumerable<IRecipe> Recipes { get; set; }
    }
}
