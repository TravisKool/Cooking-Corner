using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TestBase.Builders;
using RecipeServiceApi.Common.Models;
using System.Collections.Generic;
using TestBase.Extensions;

namespace RecipeService.UnitTests
{
    [TestClass]
    public class RecipePriceTests
    {
        private RecipePrice _recipePrice;

        [TestMethod]
        public void ShouldHaveEquivalentPriceValues()
        {
            var storeSettings = new StoreSettingsBuilder()
                .WithRoundingInCents(7)
                .WithTaxRatePercent(8.6m)
                .WithWellnessDiscountPercent(5)
                .Build();

            var builder = new RecipeBuilder();
            var expectedRecipe1 = builder.SetupRecipe1().Build();
            var expectedRecipe2 = builder.SetupRecipe2().Build();
            var expectedRecipe3 = builder.SetupRecipe3().Build();

            var actualRecipe1Prices = new RecipePrice(expectedRecipe1, storeSettings);
            var actualRecipe2Prices = new RecipePrice(expectedRecipe2, storeSettings);
            var actualRecipe3Prices = new RecipePrice(expectedRecipe3, storeSettings);

            // TODO: Override AreEqual to create a deep equality for complex object types or use 3rd party tool.
            Assert.AreEqual(expectedRecipe1.Price.Serialize(), actualRecipe1Prices.Serialize());
            Assert.AreEqual(expectedRecipe2.Price.Serialize(), actualRecipe2Prices.Serialize());
            Assert.AreEqual(expectedRecipe3.Price.Serialize(), actualRecipe3Prices.Serialize());
        }

        [TestMethod]
        public void ShouldReturnEarlyWithRecipeIdAsZero()
        {
            var storeSettingsTestData = new StoreSettingsBuilder().BuildStandardStoreSettings();
            var recipeTestData = new RecipeBuilder().SetupRecipe1().WithRecipeId(0).Build();
            _recipePrice = new RecipePrice(recipeTestData, storeSettingsTestData);

            const decimal expectedTax = 0m;
            const decimal expectedDiscount = 0m;
            const decimal expectedTotal = 0m;

            Assert.AreEqual(expectedTax, _recipePrice.Tax);
            Assert.AreEqual(expectedDiscount, _recipePrice.Discount);
            Assert.AreEqual(expectedTotal, _recipePrice.Total);
        }
    }
}
