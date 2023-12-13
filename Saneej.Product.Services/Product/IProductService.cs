using Saneej.Product.Models.Products;

namespace Saneej.Product.Services.Product
{
    public interface IProductService
    {
        Task<ActionResponse<List<ProductResponse>>> GetProductsAsync();
        Task<ActionResponse<List<ProductResponse>>> GetProductsByColorAsync(string color);
    }
}
