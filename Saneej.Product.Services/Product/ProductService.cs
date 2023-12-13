using Saneej.Product.Models.Products;
using Saneej.Product.Repository.Query;
using Saneej.Product.Services.Mappers;

namespace Saneej.Product.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly IProductQuery _iProductQuery;

        public ProductService(IProductQuery iProductQuery)
        {
            _iProductQuery = iProductQuery;
        }

        public async Task<ActionResponse<List<ProductResponse>>> GetProductsAsync()
        {
            var productEntities = await _iProductQuery.GetAllProduct();

            if (!productEntities.Any())
                return ActionResponse.CreateNotFound($"No products available.");

            var response = productEntities.Select(pe => pe.ToProductResponse()).ToList();

            return new ActionResponse<List<ProductResponse>>(response);
        }

        public async Task<ActionResponse<List<ProductResponse>>> GetProductsByColorAsync(string color)
        {
            if (string.IsNullOrWhiteSpace(color))
                return ActionResponse.CreateWithClientError("Please enter valid color.");

            var productEntities = await _iProductQuery.GetAllProductByColor(color);

            if (!productEntities.Any())
                return ActionResponse.CreateNotFound($"No products available with {color} color.");

            var response = productEntities
                            .Select(pe => pe.ToProductResponse())
                            .ToList();

            return new ActionResponse<List<ProductResponse>>(response);
        }
    }
}
