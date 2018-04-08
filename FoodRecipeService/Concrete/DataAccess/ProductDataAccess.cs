using RecipeServiceApi.Common.Contract;
using RecipeServiceApi.Common.Models;
using RecipeServiceApi.Concrete.Repository;
using System.Collections.Generic;

namespace RecipeServiceApi.Concrete.DataAccess
{
    public class ProductDataAccess : IProductDataAccess
    {
        private readonly IProductRepository _productRepository;

        public ProductDataAccess(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<IProduct> FetchProducts()
        {
            return _productRepository.FetchProducts();
        }
    }
}
