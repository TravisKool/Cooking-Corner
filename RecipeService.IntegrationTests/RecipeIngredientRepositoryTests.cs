using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecipeServiceApi.Common.Contract.Factory;
using RecipeServiceApi.Concrete.Repository;
using TestBase.Builders;

namespace RecipeService.IntegrationTests
{
    [TestClass]
    public class RecipeIngredientRepositoryTests
    {
        private RecipeIngredientRepository _recipeIngredientRepository;

        [TestInitialize]
        public void Init()
        {
            var productFactory = new ProductFactory();
            var productCategoryFactory = new ProductCategoryFactory();
            var recipeIngredientFactory = new RecipeIngredientFactory();
            _recipeIngredientRepository = new RecipeIngredientRepository(recipeIngredientFactory, productFactory, productCategoryFactory);
        }

        // TODO: Setup the data to be "standard" prior to fetching the store settings.
        // This will ensure that the test can be run successfully even if data was modified.
        [TestMethod]
        public void ShouldHaveAccurateRecipeIngredientValues()
        {
            var actualRecipe1Ingredients = _recipeIngredientRepository.FetchRecipeIngredients(1).ToList();
            var actualRecipe2Ingredients = _recipeIngredientRepository.FetchRecipeIngredients(2).ToList();
            var actualRecipe3Ingredients = _recipeIngredientRepository.FetchRecipeIngredients(3).ToList();

            var expectedRecipeIngredients1 = new RecipeBuilder().SetupRecipe1().Build().Ingredients.ToList();
            var expectedRecipeIngredients2 = new RecipeBuilder().SetupRecipe2().Build().Ingredients.ToList();
            var expectedRecipeIngredients3 = new RecipeBuilder().SetupRecipe3().Build().Ingredients.ToList();

            Assert.AreEqual(expectedRecipeIngredients1.Count(), actualRecipe1Ingredients.Count);
            Assert.AreEqual(expectedRecipeIngredients2.Count(), actualRecipe2Ingredients.Count);
            Assert.AreEqual(expectedRecipeIngredients3.Count(), actualRecipe3Ingredients.Count);

            for (int i = 0; i < actualRecipe1Ingredients.Count; i++)
            {
                Assert.IsTrue(actualRecipe1Ingredients[i].Equals(expectedRecipeIngredients1[i]));
            }

            for (int i = 0; i < actualRecipe2Ingredients.Count; i++)
            {
                Assert.IsTrue(actualRecipe2Ingredients[i].Equals(expectedRecipeIngredients2[i]));
            }

            for (int i = 0; i < actualRecipe3Ingredients.Count; i++)
            {
                Assert.IsTrue(actualRecipe3Ingredients[i].Equals(expectedRecipeIngredients3[i]));
            }
        }
    }
}
