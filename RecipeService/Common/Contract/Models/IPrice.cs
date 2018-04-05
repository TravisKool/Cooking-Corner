
namespace RecipeServiceApi.Common.Models
{
    /// <summary>
    /// Price interface
    /// </summary>
    public interface IPrice
    {
        decimal Discount { get; set; }

        decimal Total { get; set; }

        decimal Tax { get; set; }
    }
}
