
using System.Linq;

namespace RecipeServiceApi.Common.Models
{
    public class RecipePrice : IPrice
    {
        public decimal Discount { get; set; }

        public decimal Total { get; set; }

        public decimal Tax { get; set; }

        public RecipePrice(IRecipe recipe, IStoreSettings storeSettings)
        {
            Discount = CalculateDiscount(recipe, storeSettings.WellnessDiscountPercent);
            Tax = CalculateTax(recipe, storeSettings.TaxRatePercent);
            Total = CalculateTotal(recipe);
        }

        public decimal CalculateDiscount(IRecipe recipe, decimal percentDiscount)
        {
            return recipe.Ingredients
               .Where(i => i.Product.IsOrganic)
               .Sum(i => i.Product.Price) * (percentDiscount / 100);
        }

        public decimal CalculateTotal(IRecipe recipe)
        {
           return recipe.Ingredients.Sum(i => i.Product.Price) - Discount + Tax;
        }

        public decimal CalculateTax(IRecipe recipe, decimal taxPercent)
        {
            return recipe.Ingredients
                .Where(i => i.Product.ProductCategory.IsTaxable)
                .Sum(i => i.Product.Price) * taxPercent;
        }

        /// <summary>
        /// Rounds the given cents up to the nearest 7 cents.
        /// </summary>
        /// <param name="taxInCents"></param>
        /// <returns>Returns the dollar equivalent. (Ex: 107 cents input returns 1.07 output)</returns>
        private decimal RoundUpToNearestSevenCents(int taxInCents)
        {
            // Return early if the number is already a multiple of 7
            if (taxInCents % 7 == 0)
            {
                return taxInCents;
            }
            else
            {
                // Find how many cents need to be added to round up to the nearest 7 cents.
                // Add that amount and convert from cents back to dollars.
                return (taxInCents + (7 - ((taxInCents * 100) % 7))) / 100;
            }
        }
    }
}
