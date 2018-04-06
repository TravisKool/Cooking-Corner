using System.Collections.Generic;

namespace RecipeServiceApi.Common.Models
{
    public class Recipe : IRecipe
    {
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public IEnumerable<IRecipeIngredient> Ingredients { get; set; }
        public IPrice Price { get; set; }
    }
}
