
namespace RecipeServiceApi.Common.Models
{
    /// <summary>
    /// Product
    /// </summary>
    public interface IProduct
    {
        /// <summary>
        /// ProductId
        /// </summary>
        int ProductId { get; set; }

        /// <summary>
        /// ProductCategory
        /// </summary>
        IProductCategory ProductCategory { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Price
        /// </summary>
        decimal Price { get; set; }

        /// <summary>
        /// IsOrganic
        /// </summary>
        bool IsOrganic { get; set; }
    }
}
