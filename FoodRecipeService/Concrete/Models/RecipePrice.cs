
using System;
using System.Linq;

namespace RecipeServiceApi.Common.Models
{
    /// <summary>
    /// The RecipePrice class calculates the tax, discount and total prices given a recipe and
    /// the current store settings.
    /// </summary>
    public class RecipePrice : IPrice
    {
        public decimal Tax { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }

        public RecipePrice(IRecipe recipe, IStoreSettings storeSettings)
        {
            if (recipe.RecipeId == 0) return;

            Discount = CalculateOrganicDiscount(recipe, storeSettings);
            Tax = CalculateTax(recipe, storeSettings);
            Total = CalculateTotal(recipe);

            // Now that Total has been calculated, we can
            Discount = decimal.Round(Discount, 2, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// Calculates the discount which is applied only to organic items.
        /// </summary>
        /// <param name="recipe"></param>
        /// <param name="storeSettings"></param>
        /// <returns></returns>
        private decimal CalculateOrganicDiscount(IRecipe recipe, IStoreSettings storeSettings)
        {
            // Intentionally not rounding. The total amount will be rounded at the end.
            var discount = recipe.Ingredients
               .Where(i => i.Product.IsOrganic)
               .Sum(i => i.Product.Price * i.Quantity) * (storeSettings.WellnessDiscountPercent / 100);
            return SetupRounding(discount, 1);
        }

        /// <summary>
        /// Total includes Tax and Discount. Ensure these are initialized prior to invoking this method.
        /// </summary>
        /// <param name="recipe"></param>
        /// <returns></returns>
        private decimal CalculateTotal(IRecipe recipe)
        {
            var total = recipe.Ingredients
                .Sum(i => (i.Product.Price * i.Quantity)) - Discount + Tax;

            return SetupRounding(total, 1);
        }

        /// <summary>
        /// Calculates the tax based on the taxable items and then rounds up to the nearest 7 cents.
        /// </summary>
        /// <param name="recipe"></param>
        /// <param name="taxPercent"></param>
        /// <returns></returns>
        private decimal CalculateTax(IRecipe recipe, IStoreSettings storeSettings)
        {
            var tax = recipe.Ingredients
                .Where(i => i.Product.ProductCategory.IsTaxable)
                .Sum(i => i.Product.Price * i.Quantity) * (storeSettings.TaxRatePercent / 100);
            return SetupRounding(tax, storeSettings.RoundingInCents);
        }

        /// <summary>
        /// This method takes in a dollar amount as well as the integer of how many cents to round up to.
        /// It first converts to cents, before rounding, then returns the dollar amount.
        /// </summary>
        /// <param name="amountInDollars"></param>
        /// <param name="roundingInCents"></param>
        /// <returns>The rounded dollar amount</returns>
        private decimal SetupRounding(decimal amountInDollars, int roundingInCents)
        {
            return RoundUp(amountInDollars * 100, roundingInCents) / 100;
        }

        /// <summary>
        /// Round amountInCents up to the next multiple roundingInCents
        /// Ex: 14.12345 -> 14.14
        /// Ex: 14.00001 -> 14.07
        /// Ex: 7.1 -> 7.14
        /// Ex: 100 -> 100.03
        /// </summary>
        /// <param name="amountInCents"></param>
        /// <param name="roundingInCents"></param>
        /// <returns>Cents rouded up to the next multiple of roundingInCents. Divide by 100 to get dollar equivalent.</returns>
        private static decimal RoundUp(decimal amountInCents, int roundingInCents)
        {
            // Return when tax is a multiple of roundingInCents
            if (amountInCents % roundingInCents == 0)
            {
                return amountInCents;
            }

            // Cast to int to remove any decimals which would be equivalent to less than 1 cent and aren't needed.
            // If there is a decimal place and/or if the current taxInCents isn't a multiple of roundingInCents,
            // then the next integer will be tested until the base case is met.
            return RoundUp((int)amountInCents + 1, roundingInCents);
        }
    }
}
