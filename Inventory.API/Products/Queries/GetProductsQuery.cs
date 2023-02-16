using Inventory.Domain.Abstractions;
using Inventory.Domain.Entities;
using MediatR;

namespace Inventory.API.Products.Queries
{
    public class GetProductsQuery : IRequest<IEnumerable<Product>> { }

    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository;
        public GetProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var result = _productRepository.GetAll().ToList();
            return result;
        }
    }
}
