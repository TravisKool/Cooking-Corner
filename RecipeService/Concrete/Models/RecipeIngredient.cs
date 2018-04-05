
namespace RecipeServiceApi.Common.Models
{
    public class RecipeIngredient : IRecipeIngredient
    {
        public int RecipeId { get; set; }
        public IProduct Product { get; set; }
        public int Quantity { get; set; }
        public string Units { get; set; }
    }
}
