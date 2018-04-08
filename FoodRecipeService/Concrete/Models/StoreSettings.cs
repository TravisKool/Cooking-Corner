
namespace RecipeServiceApi.Common.Models
{
    public class StoreSettings : IStoreSettings
    {
        public decimal TaxRatePercent { get; set; }
        public int RoundingInCents { get; set; }
        public decimal WellnessDiscountPercent { get; set; }
    }
}
