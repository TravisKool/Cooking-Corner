using RecipeServiceApi.Common.Models;
using System;
using System.Collections.Generic;

namespace RecipeServiceApi.Common.Response
{
    [Serializable]
    public class ProductResponse
    {
        public List<Product> Products { get; set; }
    }
}
