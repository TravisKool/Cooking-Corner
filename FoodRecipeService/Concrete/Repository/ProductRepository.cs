using RecipeServiceApi.Common.Contract.Factory;
using RecipeServiceApi.Common.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace RecipeServiceApi.Concrete.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IProductFactory _productFactory;
        private readonly IProductCategoryFactory _productCategoryFactory;

        public ProductRepository(IProductFactory productFactory,
            IProductCategoryFactory productCategoryFactory)
        {
            _productFactory = productFactory;
            _productCategoryFactory = productCategoryFactory;
        }

        public IEnumerable<IProduct> FetchProducts()
        {
            var sql = @"
                SELECT		p.ProductId,
			                p.ProductCategoryId,
			                p.Name,
			                p.Description,
			                p.Price,
			                p.Units,
			                p.IsOrganic,
			                pc.Name as ProductCategoryName,
			                pc.IsTaxable
                FROM		Product p
                LEFT JOIN	ProductCategory pc ON p.ProductCategoryId = pc.ProductCategoryId
            ";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(sql, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    var products = new List<IProduct>();
                    while (reader.Read())
                    {
                        var productCategory = _productCategoryFactory.Create();
                        productCategory.ProductCategoryId = (int)reader["ProductCategoryId"];
                        productCategory.Name = reader["ProductCategoryName"].ToString();
                        productCategory.IsTaxable = (bool)reader["IsTaxable"];

                        var product = _productFactory.Create();
                        product.ProductId = (int)reader["ProductId"];
                        product.ProductCategory = productCategory;
                        product.Name = reader["Name"].ToString();
                        product.Description = reader["Description"].ToString();
                        product.Price = (decimal)reader["Price"];
                        product.Units = reader["Units"].ToString();
                        product.IsOrganic = (bool)reader["IsOrganic"];

                        products.Add(product);
                    }
                    return products;
                }
                catch (Exception ex)
                {
                    // Log error
                    return null;
                }
            }
        }
    }
}
