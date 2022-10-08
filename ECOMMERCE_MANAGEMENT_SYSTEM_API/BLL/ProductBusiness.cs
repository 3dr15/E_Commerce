using BLL.Interfaces;
using DAL.Data;
using DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;

namespace BLL
{
    public class ProductBusiness : IProductBusiness
    {
        private readonly ECommerceContext _context;
        public ProductBusiness(ECommerceContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<Product>, int)> GetProducts(int pageSize, int pageNumber)
        {
            if (pageNumber <= 0) {
                pageNumber = 0; 
            } 
            else
            {
                pageNumber--;
            }
            if (pageSize <= 0) {
                pageSize = 10;
            }

            var totalRecordsCount = await _context.Product.CountAsync();
            var products = await _context.Product
                .Include(x => x.Category)
                .Skip(pageSize * pageNumber)                            
                .Take(pageSize)
                .ToListAsync();

            return (products, totalRecordsCount);
        }

        public async Task<Product?> GetProduct(Guid id)
        {
            return await _context.Product.Include(x => x.Category).FirstOrDefaultAsync(product => product.ProductId == id);
        }

        public async Task UpdateProduct(Product product)
        {
            if (product.ExpiryDate.HasValue)
                this.ValidateExpirationDate(product.ExpiryDate.Value);

            _context.Entry(product).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task<Product> AddProduct(Product product)
        {
            if (product.ExpiryDate.HasValue)
                this.ValidateExpirationDate(product.ExpiryDate.Value);

            _context.Product.Add(product);
            await _context.SaveChangesAsync();

            return product;
        }

        private void ValidateExpirationDate(DateTimeOffset expiryDate)
        {
            if(expiryDate.ToUniversalTime() <= DateTimeOffset.UtcNow)
            {
                throw new InvalidOperationException("Expiry date must be future date.");
            }
        }

        public async Task DeleteProduct(Guid id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product != null)
            {
                _context.Product.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public bool DoesProductExists(Guid id)
        {
            return _context.Product.Any(e => e.ProductId == id);
        }
    }
}