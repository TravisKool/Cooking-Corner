using RecipeServiceApi.Common.Contract.Factory;
using RecipeServiceApi.Common.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace RecipeServiceApi.Concrete.DataAccess
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly IRecipeFactory _recipeFactory;
        private readonly IProductFactory _productFactory;
        private readonly IProductCategoryFactory _productCategoryFactory;
        private readonly IRecipeIngredientFactory _recipeIngredientFactory;

        public RecipeRepository(IRecipeFactory recipeFactory,
            IProductFactory productFactory,
            IProductCategoryFactory productCategoryFactory,
            IRecipeIngredientFactory recipeIngredientFactory)
        {
            _recipeFactory = recipeFactory;
            _productFactory = productFactory;
            _productCategoryFactory = productCategoryFactory;
            _recipeIngredientFactory = recipeIngredientFactory;
        }

        public IEnumerable<IRecipe> FetchRecipes()
        {
            var sql = @"
                SELECT		Recipe.RecipeId,
			                Recipe.Name AS RecipeName,
                FROM		Recipe
            ";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["DefaultConnection"]))
            {
                
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(sql, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    var existingRecipes = new List<IRecipe>();
                    while (reader.Read())
                    {
                        var recipe = _recipeFactory.Create();
                        recipe.Name = reader["RecipeName"].ToString();
                        recipe.RecipeId = (int)reader["RecipeId"];
                        existingRecipes.Add(recipe);
                    }
                    return existingRecipes;
                }
                catch
                {
                    // Log error
                    return null;
                }
            }
        }
    }
}
