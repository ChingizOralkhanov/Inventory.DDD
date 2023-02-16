using Inventory.Domain.Abstractions;
using Inventory.Domain.Entities;
using Inventory.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.API.Products.Queries
{
    public class GetProductsCountByStatusQuery : IRequest<int>
    {
        public ProductStatus Status { get; set; }
    }

    public class GetProductsCountByStatusQueryHandler : IRequestHandler<GetProductsCountByStatusQuery, int>
    {
        public readonly IProductRepository _productRepository;
        public GetProductsCountByStatusQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<int> Handle(GetProductsCountByStatusQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProductCountAsync(request.Status, cancellationToken);
        }
    }
}
