using Inventory.Domain.Entities;
using Inventory.Domain.Enums;

namespace Inventory.Domain.Abstractions
{
    public interface IProductRepository : IRepository<Product>
    {
        public Task<int> GetProductCountAsync(ProductStatus productStatus, CancellationToken cancellationToken);
        public Task SellProduct(Guid productId, CancellationToken cancellationToken);
    }
}
