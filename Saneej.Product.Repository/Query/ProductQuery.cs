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
                new Data.Product {ProductId = 1, Name = "BMW 5 Series", Description = "BMW 5 Series - Automatic", Color = "White", Quantity = 2},
                new Data.Product {ProductId = 2, Name = "BMW 5 Series", Description = "BMW 5 Series - Automatic", Color = "White", Quantity = 4},
                new Data.Product {ProductId = 3, Name = "BMW 5 Series", Description = "BMW 5 Series - Automatic", Color = "White", Quantity = 3},
                new Data.Product {ProductId = 4, Name = "BMW 5 Series", Description = "BMW 5 Series - Automatic", Color = "Blue", Quantity = 2},
                new Data.Product {ProductId = 5, Name = "BMW 5 Series", Description = "BMW 5 Series - Automatic", Color = "Blue", Quantity = 24},
                new Data.Product {ProductId = 6, Name = "Tesla Model 3", Description = "Tesla Model 3 - Full option", Color = "Red", Quantity = 2},
                new Data.Product {ProductId = 7, Name = "Tesla Model 3", Description = "Tesla Model 3 - Full option", Color = "Red", Quantity = 1},
                new Data.Product {ProductId = 8, Name = "Tesla Model 3", Description = "Tesla Model 3 - Full option", Color = "Red", Quantity = 5},
                new Data.Product {ProductId = 9, Name = "Tesla Model 3", Description = "Tesla Model 3 - Full option", Color = "Red", Quantity = 2},
                new Data.Product {ProductId = 10, Name = "Tesla Model 3", Description = "Tesla Model 3 - Full option", Color = "White", Quantity = 2},
                new Data.Product {ProductId = 11, Name = "Tesla Model 3", Description = "Tesla Model 3 - Full option", Color = "Red", Quantity = 2},
                new Data.Product {ProductId = 12, Name = "Tesla Model 3", Description = "Tesla Model 3 - Full option", Color = "Blue", Quantity = 2},
                new Data.Product {ProductId = 13, Name = "Tesla Model 3", Description = "Tesla Model 3 - Full option", Color = "Blue", Quantity = 2},
                new Data.Product {ProductId = 14, Name = "Audi Q7", Description = "Audi Q7 - Hybrid", Color = "White", Quantity = 1},
                new Data.Product {ProductId = 15, Name = "Audi Q7", Description = "Audi Q7 - Hybrid", Color = "White", Quantity = 6},
                new Data.Product {ProductId = 16, Name = "Audi Q7", Description = "Audi Q7 - Hybrid", Color = "Red", Quantity = 2},
                new Data.Product {ProductId = 17, Name = "Audi Q7", Description = "Audi Q7 - Hybrid", Color = "White", Quantity = 2},
                new Data.Product {ProductId = 18, Name = "Audi Q7", Description = "Audi Q7 - Hybrid", Color = "White", Quantity = 2 },
                new Data.Product {ProductId = 19, Name = "Audi Q7", Description = "Audi Q7 - Hybrid", Color = "Blue", Quantity = 2},
                new Data.Product {ProductId = 20, Name = "Audi Q7", Description = "Audi Q7 - Hybrid", Color = "Red", Quantity = 4},
            };
        }
    }
}
