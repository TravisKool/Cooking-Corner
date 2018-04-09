using RecipeServiceApi.Common.Models;

namespace TestBase.Builders
{
    public sealed class StoreSettingsBuilder
    {
        private int _roundingInCents = 0;
        private decimal _taxRatePercent;
        private decimal _wellnessDiscountPercent;

        public StoreSettingsBuilder WithRoundingInCents(int cents)
        {
            _roundingInCents = cents;
            return this;
        }

        public StoreSettingsBuilder WithTaxRatePercent(decimal taxRatePercent)
        {
            _taxRatePercent = taxRatePercent;
            return this;
        }

        public StoreSettingsBuilder WithWellnessDiscountPercent(decimal wellnessDiscountPercent)
        {
            _wellnessDiscountPercent = wellnessDiscountPercent;
            return this;
        }

        public StoreSettings BuildStandardStoreSettings()
        {
            WithRoundingInCents(7);
            WithTaxRatePercent(8.6m);
            WithWellnessDiscountPercent(5);
            return Build();
        }

        public StoreSettings Build()
        {
            return new StoreSettings
            {
                RoundingInCents = _roundingInCents,
                TaxRatePercent = _taxRatePercent,
                WellnessDiscountPercent = _wellnessDiscountPercent
            };
        }
    }
}
