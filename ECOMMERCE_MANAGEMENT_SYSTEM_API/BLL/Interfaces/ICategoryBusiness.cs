using DAL.Entity;

namespace BLL.Interfaces
{
    public interface ICategoryBusiness
    {
        Task<IEnumerable<Category>> GetCategories();
    }
}