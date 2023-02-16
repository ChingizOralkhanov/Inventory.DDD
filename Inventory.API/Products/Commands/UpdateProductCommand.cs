using Inventory.Domain.Abstractions;
using Inventory.Domain.Entities;
using MediatR;

namespace Inventory.API.Products.Commands
{
    public class UpdateProductCommand : IRequest
    {
        public Product Product { get; set; }
    }
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IProductRepository _productRepository;
        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            await _productRepository.UpdateAsync(request.Product, cancellationToken);
            return Unit.Value;
        }
    }
}
