using DAL.Entity;

namespace BLL.Interfaces
{
    public interface IProductBusiness
    {
        Task<(IEnumerable<Product>, int)> GetProducts(int pageSize, int pageNumber);
        Task<Product?> GetProduct(Guid id);
        Task<Product> AddProduct(Product product);
        Task UpdateProduct(Product product);
        bool DoesProductExists(Guid id);
        Task DeleteProduct(Guid id);
    }
}