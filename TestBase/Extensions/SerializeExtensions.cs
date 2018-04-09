using Newtonsoft.Json;
using RecipeServiceApi.Common.Models;

namespace TestBase.Extensions
{
    public static class SerializeExtensions
    {
        public static string Serialize( this IPrice price)
        {
            return JsonConvert.SerializeObject(price);
        }

        public static string Serialize(this IRecipe recipe)
        {
            return JsonConvert.SerializeObject(recipe);
        }

        public static string Serialize<T>(this T recipe)
        {
            return JsonConvert.SerializeObject(recipe);
        }
    }
}
