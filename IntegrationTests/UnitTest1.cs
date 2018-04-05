using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecipeServiceApi.Concrete.DataAccess;

namespace IntegrationTests
{
    [TestClass]
    public class UnitTest1
    {
        private readonly RecipeDataAccess _recipeDataAccess;
        private readonly Mock<IRecipeRepository> _recipeRepository;
        private readonly IRecipeIngredientRepository _recipeIngredientRepository;
        private readonly IStoreSettingsRepository _storeSettingsRepository;
        private readonly IPriceFactory _priceFactory;

        [ClassInitialize]
        public UnitTest1()
        {
            var mockRecipeRepository = new Mock<IRecipeRepository>();
            _recipeDataAccess = new RecipeDataAccess();
        }

        [TestMethod]
        public void TestMethod1()
        {

        }
    }
}
