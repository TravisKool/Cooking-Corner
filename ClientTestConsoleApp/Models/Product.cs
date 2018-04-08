
namespace RecipeServiceApi.Common.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Units { get; set; }
        public bool IsOrganic { get; set; }
    }
}
