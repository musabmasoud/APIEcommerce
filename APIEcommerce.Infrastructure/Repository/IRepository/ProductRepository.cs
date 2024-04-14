using APIEcommerce.Infrastructure.Data;
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
        public Task<IProduct> Create(IProduct Product)
        {
            throw new NotImplementedException();
        }

        public Task<IProduct> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<IProduct>> GetAllProduct()
        {
            throw new NotImplementedException();
        }

        public Task<IProduct> GetProduct(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IProduct> Update(Guid id, IProduct Product)
        {
            throw new NotImplementedException();
        }
    }
}
