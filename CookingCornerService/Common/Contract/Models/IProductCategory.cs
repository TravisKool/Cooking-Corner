
namespace RecipeServiceApi.Common.Models
{
    /// <summary>
    /// ProductCategory
    /// </summary>
    public interface IProductCategory
    {
        /// <summary>
        /// ProductCategoryId
        /// </summary>
        int ProductCategoryId { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// IsTaxable
        /// </summary>
        bool IsTaxable { get; set; }
    }
}
