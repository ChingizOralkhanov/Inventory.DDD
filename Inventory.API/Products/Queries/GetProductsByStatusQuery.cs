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
    public class GetProductsByStatusQuery : IRequest<IEnumerable<Product>>
    {
        public ProductStatus Status { get; set; }
    }

    public class GetProductsByStatusQueryHandler : IRequestHandler<GetProductsByStatusQuery, IEnumerable<Product>>
    {
        public async Task<IEnumerable<Product>> Handle(GetProductsByStatusQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
