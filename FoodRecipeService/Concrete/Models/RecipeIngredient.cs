
using System.Collections.Generic;

namespace RecipeServiceApi.Common.Models
{
    public class RecipeIngredient : IRecipeIngredient
    {
        public int RecipeId { get; set; }
        public IProduct Product { get; set; }
        public decimal Quantity { get; set; }
        public string Units { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as RecipeIngredient;

            if (other == null)
                return false;

            if (RecipeId != other.RecipeId || 
                Quantity != other.Quantity ||
                Units != other.Units)
                return false;

            // Compare Product
            return Product.Equals(other.Product);
        }

        public override int GetHashCode()
        {
            var hashCode = -1360180430;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Units);
            hashCode = hashCode * -1521134295 + RecipeId.GetHashCode();
            hashCode = hashCode * -1521134295 + Quantity.GetHashCode();
            hashCode = hashCode * -1521134295 + Product.GetHashCode();
            return hashCode;
        }
    }
}
