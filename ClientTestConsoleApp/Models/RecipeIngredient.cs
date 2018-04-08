
namespace RecipeServiceApi.Common.Models
{
    public class RecipeIngredient
    {
        public int RecipeId { get; set; }
        public Product Product { get; set; }
        public decimal Quantity { get; set; }
        public string Units { get; set; }
    }
}
