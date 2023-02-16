using Inventory.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.API.Products.Commands
{
    public class SellProductCommand : IRequest
    {
        public Guid Id { get; set; }
    }
    public class SellProductCommandHandler : IRequestHandler<SellProductCommand>
    {
        private readonly IProductRepository _productRepository;
        public SellProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(SellProductCommand request, CancellationToken cancellationToken)
        {
            await _productRepository.SellProduct(request.Id, cancellationToken);
            return Unit.Value;
        }
    }
}
