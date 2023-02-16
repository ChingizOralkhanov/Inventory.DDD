using Inventory.Domain.Abstractions;
using Inventory.Domain.Entities;
using Inventory.Domain.Enums;
using Inventory.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Infrastructure.DataAccess.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<int> GetProductCountAsync(ProductStatus productStatus, CancellationToken cancellationToken)
        {
            return await _dbContext.Products.Where(p => p.ProductStatus == productStatus).CountAsync();
        }
        public async Task SellProduct(Guid productId, CancellationToken cancellationToken)
        {
            var product = _dbContext.Products.GetFirstOrDefaultAsync(p => p.Id == productId, cancellationToken).Result;
            product.ProductStatus = ProductStatus.Sold;
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
