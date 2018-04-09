using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecipeServiceApi.Common.Contract.Factory;
using RecipeServiceApi.Common.Models;
using RecipeServiceApi.Concrete.Repository;
using TestBase.Builders;
using System.Linq;
using TestBase.Extensions;

namespace RecipeService.IntegrationTests
{
    [TestClass]
    public class RecipeRepositoryTests
    {
        private RecipeRepository _recipeRepository;

        [TestInitialize]
        public void Init()
        {
            var recipeFactory = new RecipeFactory();
            var productFactory = new ProductFactory();
            var productCategoryFactory = new ProductCategoryFactory();
            var recipeIngredientFactory = new RecipeIngredientFactory();
            _recipeRepository = new RecipeRepository(recipeFactory, productFactory, productCategoryFactory, recipeIngredientFactory);
        }

        // TODO: Setup the data to be "standard" prior to fetching the store settings.
        // This will ensure that the test can be run successfully even if data was modified.
        [TestMethod]
        public void ShouldHaveAccurateRecipeValues()
        {
            var actual = _recipeRepository.FetchRecipes().ToList();

            var expectedRecipe1 = new RecipeBuilder()
                .WithRecipeId(1)
                .WithRecipeName("Recipe 1")
                .Build();
            var expectedRecipe2 = new RecipeBuilder()
                .WithRecipeId(2)
                .WithRecipeName("Recipe 2")
                .Build();
            var expectedRecipe3 = new RecipeBuilder()
                .WithRecipeId(3)
                .WithRecipeName("Recipe 3")
                .Build();

            Assert.AreEqual(expectedRecipe1.Serialize(), actual[0].Serialize());
            Assert.AreEqual(expectedRecipe2.Serialize(), actual[1].Serialize());
            Assert.AreEqual(expectedRecipe3.Serialize(), actual[2].Serialize());
        }
    }
}
