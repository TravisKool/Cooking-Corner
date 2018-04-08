using RecipeServiceApi.Common.Models;
using System;
using System.Collections.Generic;

namespace RecipeServiceApi.Common.Response
{
    [Serializable]
    public class ProductResponse
    {
        public IEnumerable<IProduct> Products { get; set; }
    }
}
