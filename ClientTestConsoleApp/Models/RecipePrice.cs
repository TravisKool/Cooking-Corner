

namespace RecipeServiceApi.Common.Models
{
    /// <summary>
    /// The RecipePrice class calculates the tax, discount and total prices given a recipe and
    /// the current store settings.
    /// </summary>
    public class RecipePrice
    {
        public decimal Tax { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
    }
}
