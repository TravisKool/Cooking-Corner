
using System.Collections.Generic;

namespace RecipeServiceApi.Common.Models
{
    public class Product : IProduct
    {
        public int ProductId { get; set; }
        public IProductCategory ProductCategory { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Units { get; set; }
        public bool IsOrganic { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as Product;

            if (other == null)
                return false;

            if (ProductId != other.ProductId ||
                Name != other.Name ||
                Description != other.Description ||
                Price != other.Price ||
                Units != other.Units ||
                IsOrganic != other.IsOrganic)
                return false;

            // Compare ProductCategory
            return ProductCategory.Equals(other.ProductCategory);
        }

        public override int GetHashCode()
        {
            var hashCode = -1360180430;
            hashCode = hashCode * -1521134295 + ProductId.GetHashCode();
            hashCode = hashCode * -1521134295 + ProductCategory.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Description);
            hashCode = hashCode * -1521134295 + Price.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Units);
            hashCode = hashCode * -1521134295 + IsOrganic.GetHashCode();
            return hashCode;
        }
    }
}
