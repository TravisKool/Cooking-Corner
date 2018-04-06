
namespace RecipeServiceApi.Common.Models
{
    public class ProductCategory : IProductCategory
    {
        public int ProductCategoryId { get; set; }
        public string Name { get; set; }
        public bool IsTaxable { get; set; }
    }
}
