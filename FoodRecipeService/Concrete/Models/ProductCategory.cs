
using System.Collections.Generic;

namespace RecipeServiceApi.Common.Models
{
    public class ProductCategory : IProductCategory
    {
        public int ProductCategoryId { get; set; }
        public string Name { get; set; }
        public bool IsTaxable { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as ProductCategory;

            if (other == null)
                return false;

            if (ProductCategoryId != other.ProductCategoryId ||
                Name != other.Name ||
                IsTaxable != other.IsTaxable)
                return false;

            return true;
        }

        public override int GetHashCode()
        {
            var hashCode = -1360180430;
            hashCode = hashCode * -1521134295 + ProductCategoryId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + IsTaxable.GetHashCode();
            return hashCode;
        }
    }
}
