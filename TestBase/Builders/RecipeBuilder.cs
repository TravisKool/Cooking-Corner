using RecipeServiceApi.Common.Models;
using System.Collections.Generic;

namespace TestBase.Builders
{
    public sealed class RecipeBuilder
    {
        // Recipe attributes
        private int _recipeId = 0;
        private string _recipeName;
        private List<RecipeIngredient> _recipeIngredients;
        private RecipePrice _recipePrice;

        public RecipeBuilder WithRecipeId(int recipeId)
        {
            _recipeId = recipeId;
            return this;
        }

        public RecipeBuilder WithRecipeName(string recipeName)
        {
            _recipeName = recipeName;
            return this;
        }

        public RecipeBuilder WithRecipeIngredients(List<RecipeIngredient> recipeIngredients)
        {
            _recipeIngredients = recipeIngredients;
            return this;
        }

        public RecipeBuilder WithRecipePrice(RecipePrice recipePrice)
        {
            _recipePrice = recipePrice;
            return this;
        }

        public RecipeBuilder SetupRecipe1()
        {
            WithRecipeId(1);
            WithRecipeName("Recipe 1");
            WithRecipeIngredients(new RecipeIngredientBuilder().BuildRecipe1IngredientsList());
            WithRecipePrice(new PriceBuilder().BuildRecipe1Prices());
            return this;
        }

        public RecipeBuilder SetupRecipe2()
        {
            WithRecipeId(2);
            WithRecipeName("Recipe 2");
            WithRecipeIngredients(new RecipeIngredientBuilder().BuildRecipe2IngredientsList());
            WithRecipePrice(new PriceBuilder().BuildRecipe2Prices());
            return this;
        }

        public RecipeBuilder SetupRecipe3()
        {
            WithRecipeId(3);
            WithRecipeName("Recipe 3");
            WithRecipeIngredients(new RecipeIngredientBuilder().BuildRecipe3IngredientsList());
            WithRecipePrice(new PriceBuilder().BuildRecipe3Prices());
            return this;
        }

        public Recipe Build()
        {
            return new Recipe
            {
                RecipeId = _recipeId,
                Name = _recipeName,
                Ingredients = _recipeIngredients,
                Price = _recipePrice
            };
        }
    }
}
