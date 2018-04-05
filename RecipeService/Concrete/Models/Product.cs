
namespace RecipeServiceApi.Common.Models
{
    public class Product : IProduct
    {
        public int ProductId { get; set; }
        public IProductCategory ProductCategory { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsOrganic { get; set; }
    }
}
