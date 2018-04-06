using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RecipeServiceApi.Common.Contract.Factory;
using RecipeServiceApi.Common.Models;
using RecipeServiceApi.Concrete.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using UnitTests;

namespace IntegrationTests
{
    [TestClass]
    public class RecipeDataAccessTests : RecipeDataAccessTestBase
    {
        private RecipeDataAccess _recipeDataAccess;
        private Mock<IRecipeRepository> _mockRecipeRepository;
        private Mock<IRecipeIngredientRepository> _mockRecipeIngredientRepository;
        private Mock<IStoreSettingsRepository> _mockStoreSettingsRepository;
        private Mock<IPriceFactory> _mockPriceFactory;

        [TestInitialize]
        public void Init()
        {
            _mockRecipeRepository = new Mock<IRecipeRepository>();
            _mockRecipeIngredientRepository = new Mock<IRecipeIngredientRepository>();
            _mockStoreSettingsRepository = new Mock<IStoreSettingsRepository>();
            _mockPriceFactory = new Mock<IPriceFactory>();
            _recipeDataAccess = new RecipeDataAccess(_mockRecipeRepository.Object,
                                                    _mockRecipeIngredientRepository.Object,
                                                    _mockStoreSettingsRepository.Object,
                                                    _mockPriceFactory.Object);
        }

        [TestMethod]
        public void ShouldFindTheCorrectCountOfRecipes()
        {
            var recipeTestData = BuildRecipeListTestData();
            _mockRecipeRepository.Setup(r => r.FetchRecipes()).Returns(recipeTestData);

            var actual = _recipeDataAccess.FetchRecipes().ToList();

            var expectedRecipeCount = recipeTestData.Count();

            Assert.AreEqual(expectedRecipeCount, actual.Count);
        }

        [TestMethod]
        public void ShouldInitializeRecipeProperties()
        {
            var recipeTestData = BuildRecipeListTestData();
            var storeSettingsTestData = BuildStoreSettingsTestData();

            _mockRecipeRepository.Setup(r => r.FetchRecipes()).Returns(recipeTestData);

            _mockStoreSettingsRepository.Setup(s => s.FetchStoreSettings()).Returns(storeSettingsTestData.Object);
            foreach (var recipe in recipeTestData)
            {
                var ingredients = BuildRecipeIngredients(recipe.RecipeId);
                //var price = BuildPrice(recipe, storeSettingsTestData.Object);
                _mockRecipeIngredientRepository.Setup(r => r.FetchRecipeIngredients(new List<int> { recipe.RecipeId })).Returns(ingredients);
                _mockPriceFactory.Setup(r => r.Create(recipe, storeSettingsTestData.Object)).Returns(new RecipePrice(recipe, storeSettingsTestData.Object));
            }
            var actual = _recipeDataAccess.FetchRecipes().ToList();

            var allIngredientsInitialized = actual.TrueForAll(r => r.Ingredients != null);
            var allPricesInitialized = actual.TrueForAll(r => r.Price != null);
            var allNamesInitialized = actual.TrueForAll(r => r.Name != null);
            var allRecipeIdsInitialized = actual.TrueForAll(r => r.RecipeId != 0);

            Assert.IsTrue(allIngredientsInitialized);
            Assert.IsTrue(allPricesInitialized);
            Assert.IsTrue(allNamesInitialized);
            Assert.IsTrue(allRecipeIdsInitialized);
        }
    }
}
