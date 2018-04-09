using RecipeServiceApi.Common.Models;
using System.Collections.Generic;

namespace TestBase.Builders
{
    public sealed class ProductCategoryBuilder
    {
        private List<ProductCategory> _standardProductCategories;

        // ProductCategory attributes
        private int _productCategoryId { get; set; }
        private string _productCategoryName { get; set; }
        private bool _isTaxable { get; set; }

        
        public ProductCategoryBuilder WithProductCategoryId(int productCategoryId)
        {
            _productCategoryId = productCategoryId;
            return this;
        }

        public ProductCategoryBuilder WithProductCategoryName(string productCategoryName)
        {
            _productCategoryName = productCategoryName;
            return this;
        }

        public ProductCategoryBuilder WithTaxableProduct(bool isTaxable)
        {
            _isTaxable = isTaxable;
            return this;
        }

        public List<ProductCategory> BuildStandardProductCategories()
        {
            _standardProductCategories = new List<ProductCategory>();

            WithProductCategoryId(1);
            WithProductCategoryName("Produce");
            WithTaxableProduct(false);
            _standardProductCategories.Add(Build());

            WithProductCategoryId(2);
            WithProductCategoryName("Meat/poultry");
            WithTaxableProduct(true);
            _standardProductCategories.Add(Build());

            WithProductCategoryId(3);
            WithProductCategoryName("Pantry");
            WithTaxableProduct(true);
            _standardProductCategories.Add(Build());

            return _standardProductCategories;
        }

        public ProductCategory Build()
        {
            return new ProductCategory
            {
                ProductCategoryId = _productCategoryId,
                Name = _productCategoryName,
                IsTaxable = _isTaxable
            };
        }
    }
}
