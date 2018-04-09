using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecipeServiceApi.Common.Contract.Factory;
using RecipeServiceApi.Concrete.Repository;
using TestBase.Builders;
using System.Linq;

namespace RecipeService.IntegrationTests
{
    [TestClass]
    public class ProductRepositoryTests
    {
        private ProductRepository _productRepository;

        [TestInitialize]
        public void Init()
        {
            var productFactory = new ProductFactory();
            var productCategoryFactory = new ProductCategoryFactory();
            _productRepository = new ProductRepository(productFactory, productCategoryFactory);
        }

        // TODO: Setup the data to be "standard" prior to fetching the store settings.
        // This will ensure that the test can be run successfully several times.
        [TestMethod]
        public void ShouldHaveAccurateValues()
        {
            var expectedProducts = new ProductBuilder().BuildStandardListOfProducts();
            var actualProducts = _productRepository.FetchProducts().ToList();

            Assert.AreEqual(expectedProducts.Count, actualProducts.Count());

            for(int i = 0; i < expectedProducts.Count; i++)
            {
                Assert.IsTrue(expectedProducts[i].Equals(actualProducts[i]));
            }
        }
    }
}
