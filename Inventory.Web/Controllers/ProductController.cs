using Inventory.API.Products.Commands;
using Inventory.API.Products.Queries;
using Inventory.Domain.Entities;
using Inventory.Web.Controllers.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : BaseCqrsController
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("getAll")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Product>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromQuery]GetProductsQuery query)
            => Ok(await _mediator.Send(query));

        [HttpGet("getCountByStatus")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByStatus([FromQuery]GetProductsByStatusQuery query)
        => Ok(await _mediator.Send(query));

        [HttpPost("updateProduct")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Guid))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommand command)
            => Ok(await _mediator.Send(command));

        [HttpPost("sellProduct")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Guid))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SellProduct([FromBody] SellProductCommand command)
            => Ok(await _mediator.Send(command));
    }
}
