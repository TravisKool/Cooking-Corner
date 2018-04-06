using Moq;
using RecipeServiceApi.Common.Models;
using System;
using System.Collections.Generic;

namespace UnitTests
{
    public class RecipeDataAccessTestBase
    {
        private const int RoundingInCents = 7;
        private const decimal TaxRatePercent = 8.6m;
        private const decimal WellnessDiscountPercent = 5;

        protected IEnumerable<IRecipe> BuildRecipeListTestData()
        {
            var recipe1 = new Mock<IRecipe>();
            recipe1.SetupGet(r => r.RecipeId).Returns(1);
            recipe1.SetupGet(r => r.Name).Returns("Recipe 1");
            var recipe2 = new Mock<IRecipe>();
            recipe2.SetupGet(r => r.RecipeId).Returns(2);
            recipe2.SetupGet(r => r.Name).Returns("Recipe 2");
            var recipe3 = new Mock<IRecipe>();
            recipe3.SetupGet(r => r.RecipeId).Returns(3);
            recipe3.SetupGet(r => r.Name).Returns("Recipe 3");

            return new List<IRecipe>
            {
                recipe1.Object,
                recipe2.Object,
                recipe3.Object
            };
        }

        protected Mock<IStoreSettings> BuildStoreSettingsTestData()
        {
            var storeSettings = new Mock<IStoreSettings>();
            storeSettings.SetupGet(s => s.RoundingInCents).Returns(RoundingInCents);
            storeSettings.SetupGet(s => s.TaxRatePercent).Returns(TaxRatePercent);
            storeSettings.SetupGet(s => s.WellnessDiscountPercent).Returns(WellnessDiscountPercent);
            return storeSettings;
        }

        protected IEnumerable<IRecipeIngredient> BuildRecipeIngredients(int recipeId)
        {
            var mockRecipeIngredients = new Mock<IRecipeIngredient>();
            mockRecipeIngredients.SetupAllProperties();
            return new List<IRecipeIngredient> { mockRecipeIngredients.Object };
        }

        protected IPrice BuildPrice(IRecipe recipe, IStoreSettings storeSettings)
        {
            //var mockPrice = new Mock<IPrice>();
            //mockPrice.Setup(p => p.cre)
            return new RecipePrice(recipe, storeSettings);
        }
    }
}
