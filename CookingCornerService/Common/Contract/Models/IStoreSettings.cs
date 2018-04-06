
namespace RecipeServiceApi.Common.Models
{
    /// <summary>
    /// StoreSettings
    /// </summary>
    public interface IStoreSettings
    {
        /// <summary>
        /// TaxRatePercent
        /// </summary>
        decimal TaxRatePercent { get; set; }

        /// <summary>
        /// RoundingInCents
        /// </summary>
        int RoundingInCents { get; set; }

        /// <summary>
        /// WellnessDiscountPercent
        /// </summary>
        decimal WellnessDiscountPercent { get; set; }
    }
}
