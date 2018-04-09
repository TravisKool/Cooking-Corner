using RecipeServiceApi.Common.Models;
using System.Collections.Generic;

namespace TestBase.Builders
{
    public sealed class PriceBuilder
    {
        private List<RecipePrice> _prices;

        // Price attributes
        private decimal _tax;
        private decimal _discount;
        private decimal _total;
        
        public PriceBuilder WithRecipeTaxTotal(decimal recipeTax)
        {
            _tax = recipeTax;
            return this;
        }

        public PriceBuilder WithRecipeDiscountTotal(decimal discountTotal)
        {
            _discount = discountTotal;
            return this;
        }

        public PriceBuilder WithRecipeTotal(decimal total)
        {
            _total = total;
            return this;
        }

        public RecipePrice BuildRecipe1Prices()
        {
            WithRecipeTaxTotal(.21m);
            WithRecipeDiscountTotal(.11m);
            WithRecipeTotal(4.45m);
            return Build();
        }

        public RecipePrice BuildRecipe2Prices()
        {
            WithRecipeTaxTotal(.91m);
            WithRecipeDiscountTotal(.09m);
            WithRecipeTotal(11.84m);
            return Build();
        }

        public RecipePrice BuildRecipe3Prices()
        {
            WithRecipeTaxTotal(.42m);
            WithRecipeDiscountTotal(.07m);
            WithRecipeTotal(8.91m);
            return Build();
        }

        public RecipePrice Build()
        {
            return new RecipePrice()
            {
                Tax = _tax,
                Discount = _discount,
                Total = _total
            };
        }
    }
}
