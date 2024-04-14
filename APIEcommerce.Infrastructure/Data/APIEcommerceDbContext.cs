using APIEcommerce.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIEcommerce.Infrastructure.Data
{
    public class APIEcommerceDbContext:DbContext
    {
        public APIEcommerceDbContext(DbContextOptions<APIEcommerceDbContext> dbContextOptions):base(dbContextOptions)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set;}
    }
}
