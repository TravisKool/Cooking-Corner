using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecipeServiceApi.Common.Contract.Factory;
using RecipeServiceApi.Concrete.Repository;
using TestBase.Builders;
namespace RecipeService.IntegrationTests
{
    [TestClass]
    public class StoreSettingsRepositoryTests
    {
        private StoreSettingsRepository _storeSettingsRepository;

        [TestInitialize]
        public void Init()
        {
            var storeSettingsFactory = new StoreSettingsFactory();
            _storeSettingsRepository = new StoreSettingsRepository(storeSettingsFactory);
        }

        // TODO: Setup the data to be "standard" prior to fetching the store settings.
        // This will ensure that the test can be run successfully several times.
        [TestMethod]
        public void ShouldHaveTheStandardSettings()
        {
            var storeSettings = new StoreSettingsBuilder().BuildStandardStoreSettings();
            var actual = _storeSettingsRepository.FetchStoreSettings();

            Assert.AreEqual(storeSettings.RoundingInCents, actual.RoundingInCents);
            Assert.AreEqual(storeSettings.TaxRatePercent, actual.TaxRatePercent);
            Assert.AreEqual(storeSettings.WellnessDiscountPercent, actual.WellnessDiscountPercent);
        }
    }
}
