using Saneej.Product.Models.Products;

namespace Saneej.Product.Services.Mappers
{
    public static class ProductMappers
    {
        public static ProductResponse ToProductResponse(this Data.Product entity)
        {
            return new ProductResponse
            {
                ProductId = entity.ProductId,
                Name = entity.Name,
                Description = entity.Description,
                Color = entity.Color
            };
        }
    }
}
