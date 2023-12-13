namespace Saneej.Product.Repository.Query
{
    public interface IProductQuery
    {
        Task<List<Data.Product>> GetAllProduct();
        Task<List<Data.Product>> GetAllProductByColor(string color);
    }
}
