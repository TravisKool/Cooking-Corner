using RecipeServiceApi.Common.Models;
using System.Collections.Generic;
using System.Linq;

namespace TestBase.Builders
{
    public sealed class RecipeIngredientBuilder
    {
        private List<RecipeIngredient> _recipeIngredients;

        // RecipeIngredient attributes
        private int _recipeId;
        private Product _product;
        private decimal _quantity;
        private string _recipeIngredientUnits;

        public RecipeIngredientBuilder WithRecipeId(int recipeId)
        {
            _recipeId = recipeId;
            return this;
        }

        public RecipeIngredientBuilder WithProduct(Product product)
        {
            _product = product;
            return this;
        }

        public RecipeIngredientBuilder WithRecipeIngredientQuantity(decimal quantity)
        {
            _quantity = quantity;
            return this;
        }

        public RecipeIngredientBuilder WithRecipeIngredientUnits(string units)
        {
            _recipeIngredientUnits = units;
            return this;
        }

        public List<RecipeIngredient> BuildRecipe1IngredientsList()
        {
            _recipeIngredients = new List<RecipeIngredient>();

            var recipe1ProductIds = new List<int> { 1, 2, 7, 9, 10 };
            var products = new ProductBuilder().BuildStandardListOfProducts()
                .Where(p => recipe1ProductIds.IndexOf(p.ProductId) != -1);

            WithRecipeId(1);
            WithProduct(products.Single(p => p.ProductId == 1));
            WithRecipeIngredientQuantity(1.00m);
            WithRecipeIngredientUnits("clove");
            _recipeIngredients.Add(Build());

            WithRecipeId(1);
            WithProduct(products.Single(p => p.ProductId == 2));
            WithRecipeIngredientQuantity(1.00m);
            WithRecipeIngredientUnits("");
            _recipeIngredients.Add(Build());

            WithRecipeId(1);
            WithProduct(products.Single(p => p.ProductId == 7));
            WithRecipeIngredientQuantity(.75m);
            WithRecipeIngredientUnits("cup");
            _recipeIngredients.Add(Build());

            WithRecipeId(1);
            WithProduct(products.Single(p => p.ProductId == 9));
            WithRecipeIngredientQuantity(.75m);
            WithRecipeIngredientUnits("teaspoon");
            _recipeIngredients.Add(Build());

            WithRecipeId(1);
            WithProduct(products.Single(p => p.ProductId == 10));
            WithRecipeIngredientQuantity(.50m);
            WithRecipeIngredientUnits("teaspoon");
            _recipeIngredients.Add(Build());

            return _recipeIngredients;
        }

        public List<RecipeIngredient> BuildRecipe2IngredientsList()
        {
            _recipeIngredients = new List<RecipeIngredient>();

            var recipe1ProductIds = new List<int> { 1, 4, 7, 8 };
            var products = new ProductBuilder().BuildStandardListOfProducts()
                .Where(p => recipe1ProductIds.IndexOf(p.ProductId) != -1);

            WithRecipeId(2);
            WithProduct(products.Single(p => p.ProductId == 1));
            WithRecipeIngredientQuantity(1.00m);
            WithRecipeIngredientUnits("clove");
            _recipeIngredients.Add(Build());

            WithRecipeId(2);
            WithProduct(products.Single(p => p.ProductId == 4));
            WithRecipeIngredientQuantity(4.00m);
            WithRecipeIngredientUnits("");
            _recipeIngredients.Add(Build());

            WithRecipeId(2);
            WithProduct(products.Single(p => p.ProductId == 7));
            WithRecipeIngredientQuantity(.50m);
            WithRecipeIngredientUnits("cup");
            _recipeIngredients.Add(Build());

            WithRecipeId(2);
            WithProduct(products.Single(p => p.ProductId == 8));
            WithRecipeIngredientQuantity(.50m);
            WithRecipeIngredientUnits("cup");
            _recipeIngredients.Add(Build());

            return _recipeIngredients;
        }

        public List<RecipeIngredient> BuildRecipe3IngredientsList()
        {
            _recipeIngredients = new List<RecipeIngredient>();

            var recipe1ProductIds = new List<int> { 1, 3, 5, 6, 7, 9, 10 };
            var products = new ProductBuilder().BuildStandardListOfProducts()
                .Where(p => recipe1ProductIds.IndexOf(p.ProductId) != -1);

            WithRecipeId(3);
            WithProduct(products.Single(p => p.ProductId == 1));
            WithRecipeIngredientQuantity(1.00m);
            WithRecipeIngredientUnits("clove");
            _recipeIngredients.Add(Build());

            WithRecipeId(3);
            WithProduct(products.Single(p => p.ProductId == 3));
            WithRecipeIngredientQuantity(4.00m);
            WithRecipeIngredientUnits("cup");
            _recipeIngredients.Add(Build());

            WithRecipeId(3);
            WithProduct(products.Single(p => p.ProductId == 5));
            WithRecipeIngredientQuantity(4.00m);
            WithRecipeIngredientUnits("slice");
            _recipeIngredients.Add(Build());

            WithRecipeId(3);
            WithProduct(products.Single(p => p.ProductId == 6));
            WithRecipeIngredientQuantity(8.00m);
            WithRecipeIngredientUnits("ounce");
            _recipeIngredients.Add(Build());

            WithRecipeId(3);
            WithProduct(products.Single(p => p.ProductId == 7));
            WithRecipeIngredientQuantity(.33m);
            WithRecipeIngredientUnits("cup");
            _recipeIngredients.Add(Build());

            WithRecipeId(3);
            WithProduct(products.Single(p => p.ProductId == 9));
            WithRecipeIngredientQuantity(1.25m);
            WithRecipeIngredientUnits("teaspoon");
            _recipeIngredients.Add(Build());

            WithRecipeId(3);
            WithProduct(products.Single(p => p.ProductId == 10));
            WithRecipeIngredientQuantity(.75m);
            WithRecipeIngredientUnits("teaspoon");
            _recipeIngredients.Add(Build());

            return _recipeIngredients;
        }

        public RecipeIngredient Build()
        {
            return new RecipeIngredient
            {
                RecipeId = _recipeId,
                Product = _product,
                Quantity = _quantity,
                Units = _recipeIngredientUnits
            };
        }
    }
}
