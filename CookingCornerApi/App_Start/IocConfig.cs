
using RecipeServiceApi.Common.Contract;
using RecipeServiceApi.Common.Contract.Factory;
using RecipeServiceApi.Common.Models;
using RecipeServiceApi.Concrete.DataAccess;
using RecipeServiceApi.Concrete.Repository;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System.Web.Http;

namespace CookingCornerApi
{
    public class IocConfig
    {
        public static void RegisterDependencies()
        {
            var container = new Container();

            BindModules(container);
            container.Verify();
            GlobalConfiguration.Configuration.DependencyResolver =
            new SimpleInjectorWebApiDependencyResolver(container);
        }

        #region bind modules
        private static void BindModules(Container container)
        {
            container.Register<IProductDataAccess, ProductDataAccess>();
            container.Register<IProductRepository, ProductRepository>();
            container.Register<IRecipeDataAccess, RecipeDataAccess>();
            container.Register<IRecipeRepository, RecipeRepository>();
            container.Register<IRecipeIngredientRepository, RecipeIngredientRepository>();
            container.Register<IStoreSettingsRepository, StoreSettingsRepository>();
            container.Register<IPriceFactory, PriceFactory>();
            container.Register<IProductCategoryFactory, ProductCategoryFactory>();
            container.Register<IProductFactory, ProductFactory>();
            container.Register<IRecipeFactory, RecipeFactory>();
            container.Register<IRecipeIngredientFactory, RecipeIngredientFactory>();
            container.Register<IStoreSettingsFactory, StoreSettingsFactory>();
            container.Register<IPrice, RecipePrice>();
            container.Register<IProduct, Product>();
            container.Register<IProductCategory, ProductCategory>();
            container.Register<IRecipe, Recipe>();
            container.Register<IRecipeIngredient, RecipeIngredient>();
            container.Register<IStoreSettings, StoreSettings>();
        }
        #endregion
    }
}
