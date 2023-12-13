namespace Saneej.Product.Repository.Query
{
    public class ProductQuery : IProductQuery
    {
        public Task<List<Data.Product>> GetAllProduct()
        {
            return Task.Run(() => CreateDefaultData());
        }

        public async Task<List<Data.Product>> GetAllProductByColor(string color)
        {
            var allproducts = await GetAllProduct();

            return allproducts
                    .Where(x => x.Color?.ToLower() == color.ToLower())
                    .ToList();
        }

        private List<Data.Product> CreateDefaultData()
        {
            return new List<Data.Product>
            {
                new Data.Product {ProductId = 1, Name = "Ruby", Description = "Curtis", Color = "Red"},
                new Data.Product {ProductId = 1, Name = "Ruby", Description = "Curtis", Color = "Red"},
                new Data.Product {ProductId = 1, Name = "Ruby", Description = "Curtis", Color = "Red"},
                new Data.Product {ProductId = 1, Name = "Ruby", Description = "Curtis", Color = "Red"},
                new Data.Product {ProductId = 1, Name = "Ruby", Description = "Curtis", Color = "Red"},
                new Data.Product {ProductId = 1, Name = "Ruby", Description = "Curtis", Color = "Red"},
                new Data.Product {ProductId = 1, Name = "Ruby", Description = "Curtis", Color = "Red"},
            };
        }
    }
}
