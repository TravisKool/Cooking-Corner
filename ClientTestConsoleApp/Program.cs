using RecipeServiceApi.Common.Models;
using RecipeServiceApi.Common.Response;
using System.Collections.Generic;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Linq;

namespace ClientTestConsoleApp
{
    public class Program
    {
        private static HttpClient client = new HttpClient();
        private const string Uri = @"http://localhost:51447/";
        private const string RecipeApi = @"api/Recipe/";
        private const string FetchAllRecipesEndpoint = @"FetchAllRecipes/";
        private const string ProductApi = @"api/Product/";
        private const string FetchAllProductsEndpoint = @"FetchAllProductsInStock/";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            RunAsync().GetAwaiter().GetResult();
        }

        #region service calls
        /// <summary>
        /// RunAsync
        /// </summary>
        /// <returns></returns>
        private static async Task RunAsync()
        {
            client.BaseAddress = new Uri(Uri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var productResponse = await GetProductsAsync($"{ProductApi} {FetchAllProductsEndpoint}");
                var recipeResponse = await GetRecipesAsync($"{RecipeApi} {FetchAllRecipesEndpoint}");
                ShowProducts(productResponse.Products);
                ShowRecipes(recipeResponse.Recipes);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }

        /// <summary>
        /// GetRecipesAsync
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private static async Task<RecipeResponse> GetRecipesAsync(string path)
        {
            RecipeResponse recipeResponse = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                recipeResponse = await response.Content.ReadAsAsync<RecipeResponse>();
            }
            return recipeResponse;
        }

        /// <summary>
        /// GetProductsAsync
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private static async Task<ProductResponse> GetProductsAsync(string path)
        {
            ProductResponse productResponse = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                productResponse = await response.Content.ReadAsAsync<ProductResponse>();
            }
            return productResponse;
        }
        #endregion

        #region Display private helpers
        /// <summary>
        /// ShowProducts
        /// </summary>
        /// <param name="products"></param>
        private static void ShowProducts(List<Product> products)
        {
            Console.WriteLine("Input");
            Console.WriteLine("Ingredients:");

            var organic = "of organic";
                Console.WriteLine("\tProduce");
            products.Where(p => p.ProductCategory.Name == "Produce").ToList()
                .ForEach(p => Console.WriteLine(string.Format("\t- 1 {0} {1} {2} = {3}"
                , p.Units
                , p.IsOrganic ? organic : ""
                , p.Name
                , string.Format("{0:C}", p.Price))));
                Console.WriteLine("\tMeat/poultry");
            products.Where(p => p.ProductCategory.Name == "Meat/poultry").ToList()
                .ForEach(p => Console.WriteLine(string.Format("\t- 1 {0} {1} {2} = {3}"
               , p.Units
               , p.IsOrganic ? organic : ""
               , p.Name
               , string.Format("{0:C}", p.Price))));
            Console.WriteLine("\tPantry");
            products.Where(p => p.ProductCategory.Name == "Pantry").ToList()
                .ForEach(p => Console.WriteLine(string.Format("\t- 1 {0} {1} {2} = {3}"
               , p.Units
               , p.IsOrganic ? organic : ""
               , p.Name
               , string.Format("{0:C}", p.Price))));

            Console.WriteLine();
        }

        /// <summary>
        /// ShowRecipes
        /// </summary>
        /// <param name="recipes"></param>
        private static void ShowRecipes(List<Recipe> recipes)
        {
            foreach (var recipe in recipes)
            {
                Console.WriteLine(recipe.Name);
                recipe.Ingredients.ForEach(i => Console.WriteLine($"\t- {i.Quantity} {i.Units}(s) of {i.Product.Name}"));
            }

            Console.WriteLine();
            Console.WriteLine("Output");
            foreach (var recipe in recipes)
            {
                Console.WriteLine(recipe.Name);
                Console.WriteLine("\tTax = " + String.Format("{0:C}", recipe.Price.Tax));
                Console.WriteLine("\tDiscount = " + String.Format("{0:C}", recipe.Price.Discount));
                Console.WriteLine("\tTotal = " + String.Format("{0:C}", recipe.Price.Total));
                Console.WriteLine();
            }
        }
        #endregion
    }
}
