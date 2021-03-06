﻿using RecipeServiceApi.Common.Contract.Factory;
using RecipeServiceApi.Common.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace RecipeServiceApi.Concrete.Repository
{
    public class RecipeIngredientRepository : IRecipeIngredientRepository
    {
        private readonly IRecipeIngredientFactory _recipeIngredientFactory;
        private readonly IProductFactory _productFactory;
        private readonly IProductCategoryFactory _productCategoryFactory;

        public RecipeIngredientRepository(IRecipeIngredientFactory recipeIngredientFactory,
            IProductFactory productFactory,
            IProductCategoryFactory productCategoryFactory)
        {
            _recipeIngredientFactory = recipeIngredientFactory;
            _productFactory = productFactory;
            _productCategoryFactory = productCategoryFactory;
        }

        public IEnumerable<IRecipeIngredient> FetchRecipeIngredients(int recipeId)
        {
            var sql = @"
                SELECT		ri.RecipeId,
							p.ProductId,
                            p.Name AS ProductName,
                            p.Description,
                            p.Price,
                            p.Units AS ProductUnits,
                            p.IsOrganic,
                            p.ProductCategoryId,
							ri.Quantity,
							ri.Units,
							pc.Name AS ProductCategoryName,
							pc.IsTaxable
                FROM		Product p LEFT JOIN RecipeIngredients ri ON p.ProductId = ri.ProductId
				LEFT JOIN	ProductCategory pc ON p.ProductCategoryId = pc.ProductCategoryId
                WHERE       ri.RecipeId = @RecipeId
            ";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(sql, connection);

                try
                {
                    command.Parameters.Add(new SqlParameter("RecipeId", recipeId));
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    var recipeIngredients = new List<IRecipeIngredient>();
                    while (reader.Read())
                    {
                        var productCategory = _productCategoryFactory.Create();
                        productCategory.ProductCategoryId = int.Parse(reader["ProductCategoryId"].ToString());
                        productCategory.Name = reader["ProductCategoryName"].ToString();
                        productCategory.IsTaxable = bool.Parse(reader["IsTaxable"].ToString());

                        var product = _productFactory.Create();
                        product.ProductId = int.Parse(reader["ProductId"].ToString());
                        product.Name = reader["ProductName"].ToString();
                        product.Description = reader["Description"].ToString();
                        product.Price = decimal.Parse(reader["Price"].ToString());
                        product.IsOrganic = bool.Parse(reader["IsOrganic"].ToString());
                        product.ProductCategory = productCategory;
                        product.Units = reader["ProductUnits"].ToString();

                        var recipeIngredient = _recipeIngredientFactory.Create();
                        recipeIngredient.Product = product;
                        recipeIngredient.RecipeId = int.Parse(reader["RecipeId"].ToString());
                        recipeIngredient.Quantity = decimal.Parse(reader["Quantity"].ToString());
                        recipeIngredient.Units = reader["Units"].ToString();
                        recipeIngredients.Add(recipeIngredient);
                    }
                    return recipeIngredients;
                }
                catch(Exception ex)
                {
                    // Log error
                    return null;
                }
            }
        }
    }
}
