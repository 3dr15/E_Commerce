using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DAL.Entity;

namespace DAL.Data
{
    public class ECommerceContext : DbContext
    {
        public ECommerceContext (DbContextOptions<ECommerceContext> options)
            : base(options)
        {
        }

        public DbSet<DAL.Entity.Product> Product { get; set; } = default!;
        public DbSet<DAL.Entity.Category> Category { get; set; } = default!;
    }
}
