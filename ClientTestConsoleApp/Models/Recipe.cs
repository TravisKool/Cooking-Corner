using System.Collections.Generic;

namespace RecipeServiceApi.Common.Models
{
    public class Recipe
    {
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public List<RecipeIngredient> Ingredients { get; set; }
        public RecipePrice Price { get; set; }
    }
}
