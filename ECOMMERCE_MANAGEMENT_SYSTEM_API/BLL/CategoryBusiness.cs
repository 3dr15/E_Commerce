using BLL.Interfaces;
using DAL.Data;
using DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace BLL
{
    public class CategoryBusiness : ICategoryBusiness
    {
        private readonly ECommerceContext _context;
        public CategoryBusiness(ECommerceContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _context.Category.ToListAsync();
        }
    }
}