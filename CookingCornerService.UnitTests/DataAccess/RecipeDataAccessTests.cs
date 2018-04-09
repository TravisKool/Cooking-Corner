using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RecipeServiceApi.Common.Contract.Factory;
using RecipeServiceApi.Common.Models;
using RecipeServiceApi.Concrete.DataAccess;
using RecipeServiceApi.Concrete.Repository;
using System.Collections.Generic;
using System.Linq;
using TestBase.Builders;

namespace RecipeService.UnitTests
{
    [TestClass]
    public class RecipeDataAccessTests
    {
        private RecipeDataAccess _recipeDataAccess;
        private Mock<IRecipeRepository> _mockRecipeRepository;
        private Mock<IRecipeIngredientRepository> _mockRecipeIngredientRepository;
        private Mock<IStoreSettingsRepository> _mockStoreSettingsRepository;
        private Mock<IPriceFactory> _mockPriceFactory;
        private List<Recipe> _recipeTestData;

        [TestInitialize]
        public void Init()
        {
            var recipe1 = new RecipeBuilder().SetupRecipe1().Build();
            var recipe2 = new RecipeBuilder().SetupRecipe2().Build();
            var recipe3 = new RecipeBuilder().SetupRecipe3().Build();

            _recipeTestData = new List<Recipe> { recipe1, recipe2, recipe3 };

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
            _mockRecipeRepository.Setup(r => r.FetchRecipes()).Returns(_recipeTestData);

            var actual = _recipeDataAccess.FetchRecipes().ToList();

            var expectedRecipeCount = _recipeTestData.Count();

            Assert.AreEqual(expectedRecipeCount, actual.Count);
        }

        [TestMethod]
        public void ShouldInitializeRecipeProperties()
        {
            var storeSettingsTestData = new StoreSettingsBuilder().BuildStandardStoreSettings();

            _mockRecipeRepository.Setup(r => r.FetchRecipes()).Returns(_recipeTestData);

            _mockStoreSettingsRepository.Setup(s => s.FetchStoreSettings()).Returns(storeSettingsTestData);
            foreach (var recipe in _recipeTestData)
            {
                var ingredients = _recipeTestData.Single(r => r.RecipeId == recipe.RecipeId).Ingredients;
                _mockRecipeIngredientRepository.Setup(r => r.FetchRecipeIngredients(recipe.RecipeId)).Returns(ingredients);
                _mockPriceFactory.Setup(r => r.Create(recipe, storeSettingsTestData)).Returns(new RecipePrice(recipe, storeSettingsTestData));
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
