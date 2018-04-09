using RecipeServiceApi.Common.Models;
using System.Collections.Generic;
using System.Linq;

namespace TestBase.Builders
{
    public sealed class ProductBuilder
    {
        private List<Product> _products;

        // Product attributes
        private int _productId;
        private ProductCategory _productCategory;
        private string _productName;
        private string _description;
        private decimal _productPrice;
        private string _productUnits;
        private bool _isOrganic;

        public ProductBuilder WithProductId(int productId)
        {
            _productId = productId;
            return this;
        }

        public ProductBuilder WithProductCategory(ProductCategory productCategory)
        {
            _productCategory = productCategory;
            return this;
        }

        public ProductBuilder WithProductName(string productName)
        {
            _productName = productName;
            return this;
        }

        public ProductBuilder WithProductDescription(string productDescription)
        {
            _description = productDescription;
            return this;
        }

        public ProductBuilder WithProductPrice(decimal productPrice)
        {
            _productPrice = productPrice;
            return this;
        }

        public ProductBuilder WithProductUnits(string units)
        {
            _productUnits = units;
            return this;
        }

        public ProductBuilder WithOrganicProduct(bool isOrganic)
        {
            _isOrganic = isOrganic;
            return this;
        }

        public List<Product> BuildStandardListOfProducts()
        {
            _products = new List<Product>();

            var productCategories = new ProductCategoryBuilder().BuildStandardProductCategories();

            var produceCategory = productCategories.Single(pc => pc.Name == "Produce");
            var meatCategory = productCategories.Single(pc => pc.Name == "Meat/poultry");
            var pantryCategory = productCategories.Single(pc => pc.Name == "Pantry");

            WithProductId(1);
            WithProductCategory(produceCategory);
            WithProductName("garlic");
            WithProductDescription("");
            WithProductPrice(.67m);
            WithProductUnits("clove");
            WithOrganicProduct(true);
            _products.Add(Build());

            WithProductId(2);
            WithProductCategory(produceCategory);
            WithProductName("lemon");
            WithProductDescription("");
            WithProductPrice(2.03m);
            WithProductUnits("");
            WithOrganicProduct(false);
            _products.Add(Build());

            WithProductId(3);
            WithProductCategory(produceCategory);
            WithProductName("corn");
            WithProductDescription("");
            WithProductPrice(.87m);
            WithProductUnits("cup");
            WithOrganicProduct(false);
            _products.Add(Build());

            WithProductId(4);
            WithProductCategory(meatCategory);
            WithProductName("chicken");
            WithProductDescription("");
            WithProductPrice(2.19m);
            WithProductUnits("breast");
            WithOrganicProduct(false);
            _products.Add(Build());

            WithProductId(5);
            WithProductCategory(meatCategory);
            WithProductName("bacon");
            WithProductDescription("");
            WithProductPrice(.24m);
            WithProductUnits("slice");
            WithOrganicProduct(false);
            _products.Add(Build());

            WithProductId(6);
            WithProductCategory(pantryCategory);
            WithProductName("pasta");
            WithProductDescription("");
            WithProductPrice(.31m);
            WithProductUnits("ounce");
            WithOrganicProduct(false);
            _products.Add(Build());

            WithProductId(7);
            WithProductCategory(pantryCategory);
            WithProductName("olive oil");
            WithProductDescription("");
            WithProductPrice(1.92m);
            WithProductUnits("cup");
            WithOrganicProduct(true);
            _products.Add(Build());

            WithProductId(8);
            WithProductCategory(pantryCategory);
            WithProductName("vinegar");
            WithProductDescription("");
            WithProductPrice(1.26m);
            WithProductUnits("cup");
            WithOrganicProduct(false);
            _products.Add(Build());

            WithProductId(9);
            WithProductCategory(pantryCategory);
            WithProductName("salt");
            WithProductDescription("");
            WithProductPrice(.16m);
            WithProductUnits("teaspoon");
            WithOrganicProduct(false);
            _products.Add(Build());

            WithProductId(10);
            WithProductCategory(pantryCategory);
            WithProductName("pepper");
            WithProductDescription("");
            WithProductPrice(.17m);
            WithProductUnits("teaspoon");
            WithOrganicProduct(false);
            _products.Add(Build());

            return _products;
        }

        public Product Build()
        {
            return new Product
            {
                ProductId = _productId,
                ProductCategory = _productCategory,
                Name = _productName,
                Description = _description,
                Price = _productPrice,
                Units = _productUnits,
                IsOrganic = _isOrganic
            };
        }
    }
}
