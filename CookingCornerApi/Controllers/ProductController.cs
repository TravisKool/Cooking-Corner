using RecipeServiceApi.Common.Contract;
using RecipeServiceApi.Common.Response;
using System.Web.Http;

namespace ProductService.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IProductDataAccess _productDataAccess;

        public ProductController(IProductDataAccess productDataAccess)
        {
            _productDataAccess = productDataAccess;
        }
        
        [HttpGet]
        public ProductResponse FetchAllProductsInStock()
        {
            return new ProductResponse
            {
                Products = _productDataAccess.FetchProducts()
            };
        }
    }
}
