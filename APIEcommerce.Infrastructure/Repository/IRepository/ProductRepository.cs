using APIEcommerce.Domain.Models;
using APIEcommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIEcommerce.Infrastructure.Repository.IRepository
{
    public class ProductRepository : IProduct
    {
        private readonly APIEcommerceDbContext dbContext;

        public ProductRepository(APIEcommerceDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Product> Create(Product Product)
        {
            await dbContext.AddAsync(Product);
            await dbContext.SaveChangesAsync();
            return Product;
        }

        public async Task<Product> Delete(Guid id)
        {
            var existingProduct = await dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (existingProduct == null)
            {
                return null;
            }
            dbContext.Products.Remove(existingProduct);
            await dbContext.SaveChangesAsync();
            return existingProduct;
        }

        public async Task<List<Product>> GetAllProduct(string? filterOn = null, string? filterQuery = null,
            string? sortBy = null, bool isAscending = true)
        {
            //filtering
            var products = dbContext.Products.Include("Category").AsQueryable();
            if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    products = products.Where(x => x.Name.Contains(filterQuery));
                }
            }
            //Sorting
            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    products = isAscending ? products.OrderBy(x => x.Name) : products.OrderByDescending(x => x.Name);
                }
                else if (sortBy.Equals("Price", StringComparison.OrdinalIgnoreCase))
                {
                    products = isAscending ? products.OrderBy(x => x.Price) : products.OrderByDescending(x => x.Price);
                }
            }
            return await products.ToListAsync();
        }

        public async Task<Product> GetProduct(Guid id)
        {
            return await dbContext.Products.Include("Category").FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Product> Update(Guid id, Product Product)
        {
            var existingProduct = await dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (existingProduct == null)
            {
                return null;
            }
            existingProduct.Name =Product.Name;
            existingProduct.Description =Product.Description;
            existingProduct.Model =Product.Model;
            existingProduct.Author = Product.Author;
            existingProduct.Price = Product.Price;
            existingProduct.OfferPrice = Product.OfferPrice;
            existingProduct.CategoryId = Product.CategoryId;
            await dbContext.SaveChangesAsync();
            return existingProduct;



        }
    }
}
