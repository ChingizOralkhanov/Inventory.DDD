using Inventory.API.Products.Commands;
using Inventory.API.Products.Queries;
using Inventory.Web.Controllers.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Web.Controllers
{
    [ApiController]
    [Route("[api/controller]")]
    public class ProductController : BaseCqrsController
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]GetProductsQuery query)
            => Ok(await _mediator.Send(query));

        [HttpGet]
        public async Task<IActionResult> GetByStatus([FromQuery]GetProductsByStatusQuery query)
        => Ok(await _mediator.Send(query));

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommand command)
            => Ok(await _mediator.Send(command));

        [HttpPut]
        public async Task<IActionResult> SellProduct([FromBody] SellProductCommand command)
            => Ok(await _mediator.Send(command));
    }
}
