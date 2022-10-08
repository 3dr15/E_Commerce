using DAL.Entity;

namespace BLL.Interfaces
{
    public interface IProductBusiness
    {
        Task<IEnumerable<Product>> GetProducts(int pageSize, int pageNumber);
        Task<Product?> GetProduct(Guid id);
        Task<Product> AddProduct(Product product);
        Task UpdateProduct(Product product);
        bool DoesProductExists(Guid id);
        Task DeleteProduct(Guid id);
    }

    public interface ICategoryBusiness
    {
        Task<IEnumerable<Category>> GetCategories();
    }
}