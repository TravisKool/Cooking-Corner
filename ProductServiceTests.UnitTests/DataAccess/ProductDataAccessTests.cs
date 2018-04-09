using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RecipeServiceApi.Common.Contract.Factory;
using RecipeServiceApi.Common.Models;
using RecipeServiceApi.Concrete.DataAccess;
using RecipeServiceApi.Concrete.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using TestBase.Builders;

namespace ProductServiceTests.UnitTests
{
    [TestClass]
    public class ProductDataAccessTests
    {
        private ProductDataAccess _productDataAccess;
        private Mock<IProductRepository> _mockProductRepository;
        private Mock<IProductFactory> _mockProductFactory;
        private List<Product> _productTestData;

        [TestInitialize]
        public void Init()
        {
            _productTestData = new ProductBuilder().BuildStandardListOfProducts();
            _mockProductRepository = new Mock<IProductRepository>();
            _mockProductFactory = new Mock<IProductFactory>();
            _productDataAccess = new ProductDataAccess(_mockProductRepository.Object);
        }

        [TestMethod]
        public void ShouldFindTheCorrectCountOfProducts()
        {
            _mockProductRepository.Setup(r => r.FetchProducts()).Returns(_productTestData);

            var actual = _productDataAccess.FetchProducts().ToList();

            var expectedProductCount = _productTestData.Count();

            Assert.AreEqual(expectedProductCount, actual.Count);
        }

        [TestMethod]
        public void ShouldInitializeAllProductProperties()
        {
            _mockProductRepository.Setup(r => r.FetchProducts()).Returns(_productTestData);
               
            var actual = _productDataAccess.FetchProducts().ToList();

            var allIngredientsInitialized = actual.TrueForAll(r => r.ProductCategory != null);
            var allNamesInitialized = actual.TrueForAll(r => r.Name != null);
            var allPricesInitialized = actual.TrueForAll(r => r.Price != 0);
            var allProductIdsInitialized = actual.TrueForAll(r => r.ProductId != 0);
            var allUnitsInitialized = actual.TrueForAll(r => r.Units != null);

            Assert.IsTrue(allIngredientsInitialized);
            Assert.IsTrue(allNamesInitialized);
            Assert.IsTrue(allPricesInitialized);
            Assert.IsTrue(allProductIdsInitialized);
            Assert.IsTrue(allUnitsInitialized);
        }
    }
}
